using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Drawing;

using WorkflowManagement;

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

        object selectedElement = null;
        bool isDirty = true;
        bool isMouseDown = false;
        public CanvasState CanvasStatus = CanvasState.None;
        NewConnector NewConnection = null;

        int delX = 0;
        int delY = 0;

        public Canvas(Size canvas_size)
        {
            CanvasSize = canvas_size;
        }
        public void Create_Block_fromDB(Guid ID, int x, int y, string Title,
                                 string Desc, string WorkInstruct, string Notes)
        {
            Block block_element = new Block();
            block_element.CreatefromDB(ID, x, y, Title, Desc, WorkInstruct, Notes);

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
        public void Create_Connector_fromDB(Guid from, Guid to)
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
            Create_Connector(NewConnection.belowBlock, NewConnection.topBlock, NewConnection.isLeftToRight);
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
                element.Draw(grfx.Graphics);
            }

            foreach (Connector con in Connectors)
            {
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
                if (con.Status != ConnectorState.Selected)
                    con.Status = ConnectorState.Normal;
            }
            foreach (Block block in Elements.Values)
            {
                block.ClearMouseOverState();
            }
        }

        private void reset_select()
        {
            foreach (Connector con in Connectors)
            {

                con.Status = ConnectorState.Normal;
            }
            foreach (Block block in Elements.Values)
            {
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
                NewConnection.belowBlock = (Block)selectedElement;
                NewConnection.isLeftToRight = true;
                CanvasStatus = CanvasState.NewConTo;
            }
            else if (CanvasStatus == CanvasState.NewConTo)
            {

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
                Block selBlock = (Block)selectedElement;
                Connector[] listCon = Connectors.ToArray();

                foreach (Connector Con in listCon)
                {
                    if (selBlock.Equals(Con.block1) || selBlock.Equals(Con.block2))
                    {
                        Connectors.Remove(Con);
                    }
                }

                Elements.Remove(((Block)selectedElement).ID);
            }
            else if (selectedElement.GetType() == typeof(Connector))
            {
                Connectors.Remove((Connector)selectedElement);
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
    }
}
