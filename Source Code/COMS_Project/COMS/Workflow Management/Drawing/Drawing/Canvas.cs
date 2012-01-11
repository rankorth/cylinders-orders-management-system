using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Drawing;

using WorkflowManagement;
using COMSdbEntity;
using System.Data.EntityClient;
using System.Data.Entity;


namespace WorkflowManagement
{
    public enum CanvasState
    {
        None        = 0,
        NewConFrom  = 1,
        NewConTo    = 2
    }
    class NewConnector
    {
        public Block belowBlock;
        public Block topBlock;
        public bool isLeftToRight;
    }

    public class Canvas
    {
        Dictionary<Guid, Block> Elements = new Dictionary<Guid, Block>();
        List<Connector> Connectors = new List<Connector>();
        public Size CanvasSize = new Size();
        private Guid WorkflowID = Guid.Empty;
        public string PreviousWorkflowName="";
        public string NextWorkflowName = "";

        object selectedElement = null;
        bool isDirty = true;
        bool isMouseDown = false;
        public CanvasState CanvasStatus = CanvasState.None;
        NewConnector NewConnection = null;

        int delX = 0;
        int delY = 0;

        public Canvas(Size canvas_size,Guid workflowID)
        {
            CanvasSize = canvas_size;
            WorkflowID = workflowID;

            LoadWorkflowFromDB();
        }
        public void Create_Block_fromDB(Guid ID, int x, int y, string Title,
                                 string Desc, string WorkInstruct, string Notes,bool isStep, bool isBegin,Formula StepFormula)
        {
            Block block_element = new Block();
            if (isStep)
            {

                block_element.CreatefromDB(ID, x, y, Title, Desc, WorkInstruct, Notes, PrepareFormula(StepFormula));
            }else if (isBegin)
            {
                block_element.CreatefromDB_Begin(ID, x, y, PreviousWorkflowName + " (BEGIN)", Desc, WorkInstruct, Notes);
            }
            else
            {
                block_element.CreatefromDB_End(ID, x, y, NextWorkflowName + "(END)", Desc, WorkInstruct, Notes);
            }
            Elements.Add(block_element.ID, block_element);

            isDirty = true;
        }
        public void Create_Block(int x, int y, string Title, int from, int to)
        {
            Block block_element = new Block();
            block_element.Create(x, y, Title);

            Elements.Add(block_element.ID, block_element);

            isDirty = true;
        }
        public void Create_Workflow_Block(int x, int y, string Title, bool isBegin)
        {
            Block block_element = new Block();

            if (isBegin)
            {
                block_element.CreateBeginBlock(x, y, PreviousWorkflowName + " (BEGIN)");
            }
            else
            {
                block_element.CreateEndBlock( x, y, NextWorkflowName + "(END)");
            }

            Elements.Add(block_element.ID, block_element);

            isDirty = true;
        }
        public void Create_Connector_fromDB(Guid ConnectorID, Guid from, Guid to)
        {
            NewConnection = new NewConnector();

            NewConnection.belowBlock = Elements[from];
            NewConnection.topBlock   = Elements[to];
            NewConnection.isLeftToRight = true;


            if (Elements.Values.ToList().IndexOf(NewConnection.belowBlock) > Elements.Values.ToList().IndexOf(NewConnection.topBlock))
            {
                Block tmpBlock;
                tmpBlock = NewConnection.belowBlock;
                NewConnection.belowBlock = NewConnection.topBlock;
                NewConnection.topBlock = tmpBlock;
                NewConnection.isLeftToRight = false;
            }

            if (NewConnection.topBlock.Equals(NewConnection.belowBlock))
            {
                NewConnection = null;
                return;
            }
            foreach (Connector con in Connectors)
            {
                if (con.block1.Equals(NewConnection.belowBlock))
                {
                    if (con.block2.Equals(NewConnection.topBlock) && con.isLeftToRight == NewConnection.isLeftToRight)
                    {
                        NewConnection = null;
                        return;
                    }
                }
            }


            CanvasStatus = CanvasState.None;
            Connector Con = new Connector(ConnectorID, NewConnection.belowBlock, NewConnection.topBlock, NewConnection.isLeftToRight);
            Connectors.Add(Con);

            NewConnection = null;
        }
        public void Create_Connector(Block BelowBlock, Block TopBlock, bool isLeftToRight)
        {
            Connector Con = new Connector(BelowBlock, TopBlock, isLeftToRight);
            Connectors.Add(Con);
        }
        
        public void Paint(Graphics graphic, int curX, int curY)
        {
            // if (!isDirty) { return; }
            graphic.PageUnit = GraphicsUnit.Pixel;

            BufferedGraphicsContext bcontext;
            BufferedGraphics grfx;
            bcontext = BufferedGraphicsManager.Current;
            bcontext.MaximumBuffer = new Size(Convert.ToInt32(graphic.VisibleClipBounds.Width),
                Convert.ToInt32(graphic.VisibleClipBounds.Height));
            grfx = bcontext.Allocate(graphic, new Rectangle(0, 0, Convert.ToInt32(graphic.VisibleClipBounds.Width),
                Convert.ToInt32(graphic.VisibleClipBounds.Height)));
            grfx.Graphics.PageUnit = GraphicsUnit.Pixel;
            grfx.Graphics.Clear(Color.GhostWhite);

            foreach (Block element in Elements.Values)
            {
                if(element.isActive)
                element.Draw(grfx.Graphics);
            }

            foreach (Connector con in Connectors)
            {
                if(con.isActive)
                con.Draw(ConnectorState.Normal, grfx.Graphics);
            }
            Show_New_Con_line(grfx.Graphics, curX, curY);
            grfx.Render(graphic);
            grfx.Dispose();
        }

        /// <summary>
        /// Check MouseOver events for all blocks elements
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns>return true if there is any mouse over event occurs, so that main application can repaint updated states.</returns>
        public bool MouseOver(int X, int Y)
        {
            bool previous_state = false;
            bool isFound = false;
            isDirty = false;

            reset_mouseover();

            Elements.Reverse();
            foreach (Block element in Elements.Values)
            {
                if (!element.isActive) { continue;  }
                previous_state = element.getPreviousMouseOverState();
                if (!isFound)
                {
                    if (element.IsMouseOver(X, Y))
                    {
                        isFound = true;
                        if (previous_state != element.getPreviousMouseOverState())
                        {
                            isDirty = true;
                        }
                    }
                }
                else
                {
                    element.ClearMouseOverState();
                }
            }
            Elements.Reverse();
            if (isFound)
            {
                return isDirty;
            }

            foreach (Connector con in Connectors)
            {
                if (!con.isActive) { continue; }
                if (con.isMouseOver(X, Y))
                {
                    isFound = true;
                    con.Status = ConnectorState.MouseOver;
                    isDirty = true;
                }
            }

            return isDirty;
        }

        private void reset_mouseover()
        {
            foreach (Connector con in Connectors)
            {
                if (!con.isActive) { continue; }
                if (con.Status != ConnectorState.Selected)
                    con.Status = ConnectorState.Normal;
            }
            foreach (Block block in Elements.Values)
            {
                if (!block.isActive) { continue; }
                block.ClearMouseOverState();
            }
        }

        private void reset_select()
        {
            foreach (Connector con in Connectors)
            {
                if (!con.isActive) { continue; }
                con.Status = ConnectorState.Normal;
            }
            foreach (Block block in Elements.Values)
            {
                if (!block.isActive) { continue; }
                block.ClearSelectedState();
            }
        }

        /// <summary>
        /// Select a block at mouse pointer.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns>return true if there is any element block is selected/de-selected, main application need to redrawn the drawin if selected status has change</returns>
        public bool Select(int X, int Y)
        {

            bool previous_state = false;
            bool isFound = false;
            isDirty = false;
            reset_select();

            Elements.Reverse();
            foreach (Block element in Elements.Values)
            {
                if (!element.isActive) { continue; }
                previous_state = element.getPreviousSelectedState();
                if (!isFound)
                {
                    if (element.IsSelected(X, Y))
                    {
                        selectedElement = element;
                        delX = X - element.x;
                        delY = Y - element.y;
                        isMouseDown = true;
                        isFound = true;
                    }
                    else
                    {
                        isMouseDown = false;
                    }
                    if (previous_state != element.getPreviousSelectedState())
                    {
                        isDirty = true;
                        //return true;
                    }
                }
                else
                {
                    element.ClearSelectedState();
                }
            }

            Elements.Reverse();
            if (!isFound) { selectedElement = null; }
            if (CanvasStatus != CanvasState.None)
            {
                DrawNewConnection();
            }
            if (isFound)
            {
                return isDirty;
            }

            foreach (Connector con in Connectors)
            {
                if (!con.isActive) { continue; }
                if (con.isMouseSelected(X, Y))
                {
                    isFound = true;
                    con.Status = ConnectorState.Selected;
                    selectedElement = con;
                    isDirty = true;
                }
            }


            return isDirty;
        }

        public bool MouseDrag(int X, int Y)
        {
            if (selectedElement == null || !isMouseDown) { return false; }
            if (selectedElement.GetType() != typeof(Block)) { return false; }

            if (X - delX <= 0 || Y - delY <= 0) { return false; }

            if (X - delX + ((Block)selectedElement).width + 3 >= CanvasSize.Width || Y - delY + ((Block)selectedElement).height + 3 >= CanvasSize.Height) { return false; }

            isDirty = ((Block)selectedElement).Move(X - delX, Y - delY);
            return isDirty;
        }

        public void MouseUp()
        {
            isMouseDown = false;
        }

        public void DrawNewConnection()
        {
            if (selectedElement == null)
            {
                clear_new_con();
                return;
            }
            if (selectedElement.GetType() != typeof(Block)) { return; }

            if (CanvasStatus == CanvasState.NewConFrom)
            {
                if (!((Block)selectedElement).isStep && !((Block)selectedElement).isBegin)
                {
                    clear_new_con();
                    return;
                }
                NewConnection.belowBlock = (Block)selectedElement;
                NewConnection.isLeftToRight = true;
                CanvasStatus = CanvasState.NewConTo;
            }
            else if (CanvasStatus == CanvasState.NewConTo)
            {
                if (!((Block)selectedElement).isStep && ((Block)selectedElement).isBegin)
                {
                    clear_new_con();
                    return;
                }

                NewConnection.topBlock = (Block)selectedElement;
                if (Elements.Values.ToList().IndexOf(NewConnection.belowBlock) > Elements.Values.ToList().IndexOf(NewConnection.topBlock))
                {
                    Block tmpBlock;
                    tmpBlock = NewConnection.belowBlock;
                    NewConnection.belowBlock = NewConnection.topBlock;
                    NewConnection.topBlock = tmpBlock;
                    NewConnection.isLeftToRight = false;


                }

                if (NewConnection.topBlock.Equals(NewConnection.belowBlock))
                {
                    clear_new_con();
                    return;
                }
                foreach (Connector con in Connectors)
                {
                    if (!con.isActive) { continue; }
                    if (con.block1.Equals(NewConnection.belowBlock))
                    {
                        if (con.block2.Equals(NewConnection.topBlock) && con.isLeftToRight == NewConnection.isLeftToRight)
                        {
                            clear_new_con();
                            return;
                        }
                    }
                }


                CanvasStatus = CanvasState.None;
                Create_Connector(NewConnection.belowBlock, NewConnection.topBlock, NewConnection.isLeftToRight);
                NewConnection = null;
            }
        }

        public void AddConnector()
        {
            if (CanvasStatus == CanvasState.None)
            {
                CanvasStatus = CanvasState.NewConFrom;
                NewConnection = new NewConnector();
            }
        }

        private void Show_New_Con_line(Graphics graphic, int X, int Y)
        {
            if (CanvasStatus != CanvasState.None && NewConnection != null)
            {
                if (NewConnection.belowBlock != null)
                    graphic.DrawLine(Pens.Gray, NewConnection.belowBlock.x + NewConnection.belowBlock.width / 2,
                                NewConnection.belowBlock.y + NewConnection.belowBlock.height / 2, X, Y);
            }
        }
        private void clear_new_con()
        {
            CanvasStatus = CanvasState.None;
            NewConnection = null;
        }

        public bool isElementSelected
        {
            get
            {
                if (selectedElement != null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool isConnectorSelected
        {

            get
            {
                bool isConSelected = false;
                if (selectedElement != null)
                {
                    if (selectedElement.GetType() == typeof(Connector))
                    {
                        isConSelected = true;
                    }
                    else
                    {
                        isConSelected = false;
                    }
                }
                return isConSelected;
            }

        }

        public void DeleteSelectedElement()
        {
            if (selectedElement.GetType() == typeof(Block))
            {
                if (!((Block)selectedElement).isStep)
                {
                    return;
                }

                Block selBlock = (Block)selectedElement;
                Connector[] listCon = Connectors.ToArray();

                foreach (Connector Con in listCon)
                {
                    if (selBlock.Equals(Con.block1) || selBlock.Equals(Con.block2))
                    {
                        //Connectors.Remove(Con);
                        Con.isActive = false;   //marked to delete from DB
                    }
                }

                //Elements.Remove(((Block)selectedElement).ID);
                ((Block)selectedElement).isActive = false; //marked to delete from DB
            }
            else if (selectedElement.GetType() == typeof(Connector))
            {
               // Connectors.Remove((Connector)selectedElement);
                ((Connector)selectedElement).isActive = false;
            }

            selectedElement = null;
        }

        public Block SelectedWorkflowActivity
        {
            get
            {
                Block activity=new Block();
                if (!isConnectorSelected)
                {
                    activity = (Block)selectedElement;
                }
                return activity;
            }
        }

        public void SaveToDatabase()
        {
            COMSEntities context=new COMSEntities();
            COMSdbEntity.Workflow workflow = context.Workflows.Where(w => w.workflowId == this.WorkflowID).SingleOrDefault();
            workflow.updated_by = "system";
            workflow.updated_date = DateTime.Now;

            bool isSavedPerformed = false;
            foreach (Block element in Elements.Values)
            {

                    element.workflowid = this.WorkflowID;
                    element.Save(context);


                isSavedPerformed = true;
            }

            if (isSavedPerformed)   //save steps first
            {
                context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                foreach (Block element in Elements.Values)
                {
                    element.ChangedToDBObject();
                }
            }

            foreach (Connector con in Connectors)
            {
                    con.workflowid = this.WorkflowID;
                    con.Save(context);
                isSavedPerformed = true;
            }

            if (isSavedPerformed)   //save connections now
            {
                context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                foreach (Connector con in Connectors)
                {
                    con.ChangedToDBObject();
                }
            }

            context.Dispose();

            
            
        }

        public void LoadWorkflowFromDB()
        {
            try
            {
                COMSEntities context = new COMSEntities();
                Workflow workflow = context.Workflows.Where(w => w.workflowId.Equals(this.WorkflowID)).SingleOrDefault();

                Workflow PreviousWorkflow = context.Workflows.Where(w => w.workflowId==workflow.prevWorkflowID).SingleOrDefault();
                Workflow NextWorkflow = context.Workflows.Where(w => w.workflowId==workflow.nextWorkflowID).SingleOrDefault();

                PreviousWorkflowName = "Nil";
                NextWorkflowName = "Nil";

                if (PreviousWorkflow != null)
                {
                    PreviousWorkflowName = PreviousWorkflow.name;
                }

                if (NextWorkflow != null)
                {
                    NextWorkflowName = NextWorkflow.name;
                }

                bool isBeginFound = false;
                bool isEndFound = false;
                foreach (Step s in workflow.Steps.Where(s => s.isActive == true))
                {
                    if (!s.isStep && s.isBegin)
                    {
                        isBeginFound = true;
                    }
                    else if (!s.isStep && !s.isBegin)
                    {
                        isEndFound = true;
                    }
                    Create_Block_fromDB(s.stepId, s.x, s.y, s.name, s.description, s.instruction, s.note, s.isStep, s.isBegin,
                        s.Formulae.Count>0? s.Formulae.First():null);
                }

                if (!isBeginFound)
                {
                    Create_Workflow_Block(10, 10, PreviousWorkflowName + "(BEGIN)", true);
                }
                if (!isEndFound)
                {
                    Create_Workflow_Block(100, 100, PreviousWorkflowName + "(END)", false);
                }

                foreach (Step_ref con in workflow.Step_ref)
                {
                    Create_Connector_fromDB(con.Id, con.from_stepId, con.to_stepId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public formula PrepareFormula(Formula StepFormula)
        {
            formula Formula = new formula();

            if (StepFormula != null)
            {
                Formula.coef1 = StepFormula.coef1;
                Formula.coef2 = StepFormula.coef2;
                Formula.coef3 = StepFormula.coef3;
                Formula.coef4 = StepFormula.coef4;
                Formula.strFormula = StepFormula.formula1;
            }
            return Formula;
        }
    }
}
