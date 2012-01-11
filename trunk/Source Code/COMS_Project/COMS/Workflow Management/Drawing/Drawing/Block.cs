using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using COMSdbEntity;

namespace WorkflowManagement
{
    public class formula
    {
        public int coef1=0;
        public int coef2=0;
        public int coef3=0;
        public int coef4=0;
        public string strFormula = "";
    }

    public class Block
    {
        private formula Formula = new formula();

        private Guid display_id = Guid.NewGuid();
        public  Guid obj_id = Guid.Empty;
        public int x { get; set; }
        public int y { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public string WorkInstruction { get; set; }
        public string Notes { get; set; }
        public bool isActive = true;
        public Guid workflowid;

        public int width { get; set; }
        public int height { get; set; }
        private bool isSelected = false;
        private bool isMouseOver = false;

        public bool isStep =true;
        public bool isBegin;

        public Guid ID
        {
            get
            {
                return this.display_id;
            }
        }
        public void CreatefromDB(Guid ID, int x, int y, string Title,
                                 string Desc, string WorkInstruct, string Notes,formula Formula)
        {
            this.obj_id = ID;
            this.display_id = ID;
            this.x = x;
            this.y = y;
            this.Title = Title;
            this.Description = Desc;
            this.WorkInstruction = WorkInstruct;
            this.Notes = Notes;
            this.isStep = true;
            this.isBegin = false;

            this.Formula = Formula;
        }

        public void CreatefromDB_Begin(Guid ID, int x, int y, string Title,
                                 string Desc, string WorkInstruct, string Notes)
        {
            this.obj_id = ID;
            this.display_id = ID;
            this.x = x;
            this.y = y;
            this.Title = Title;
            this.Description = Desc;
            this.WorkInstruction = WorkInstruct;
            this.Notes = Notes;
            this.isStep = false;
            this.isBegin = true;
        }

        public void CreatefromDB_End(Guid ID, int x, int y, string Title,
                                 string Desc, string WorkInstruct, string Notes)
        {
            this.obj_id = ID;
            this.display_id = ID;
            this.x = x;
            this.y = y;
            this.Title = Title;
            this.Description = Desc;
            this.WorkInstruction = WorkInstruct;
            this.Notes = Notes;
            this.isStep = false;
            this.isBegin = false;
        }

        public void Create(int x, int y, string Title)
        {
            this.x = x;
            this.y = y;
            this.Title = Title;
            this.isStep = true;
            this.Description = "";
            this.WorkInstruction = "";
            this.Notes = "";
        }

        public void CreateBeginBlock(int x, int y, string Title)
        {
            this.obj_id = Guid.Empty;
            this.display_id = ID;
            this.x = x;
            this.y = y;
            this.Title = Title;
            this.isStep = false;
            this.isBegin = true;
        }
        public void CreateEndBlock(int x, int y, string Title)
        {
            this.obj_id = Guid.Empty;
            this.display_id = ID;
            this.x = x;
            this.y = y;
            this.Title = Title;
            this.isStep = false;
            this.isBegin = false;
        }

        public void Draw(Graphics graphic)
        {
            //graphic.PageUnit = GraphicsUnit.Display;
            Font sFont = new Font("Arial", 10);
            Pen retPen = new Pen(Brushes.Black, 1);
            Brush retFill = Brushes.White;
            Brush textColor = Brushes.Black;

            if (this.isStep)
            {
                if (isMouseOver) { retPen = new Pen(Brushes.Orange, 2); retFill = Brushes.LightYellow; }
                if (isSelected) { retPen = new Pen(Brushes.Black, 1); retFill = Brushes.Orange; }
            }else
            {
                if (this.isBegin)
                {
                    retFill     = Brushes.Blue;
                    textColor   = Brushes.White; 
                }
                else
                {
                    retFill = Brushes.Black;
                    textColor = Brushes.White; 
                }
            }

            SizeF sSize = graphic.MeasureString(Title, sFont);
            width = Convert.ToInt32(sSize.Width) + 2;
            height = Convert.ToInt32(sSize.Height) + 2;
            Rectangle block = new Rectangle(x, y, width, height);
            graphic.FillRectangle(retFill, block);
            graphic.DrawRectangle(retPen, block);

            graphic.DrawString(Title, sFont, textColor, new Point(x + 2, y + 2));

            if (isSelected)
            {
                SelectedHandles(graphic);
            }
        }
        public void SelectedHandles(Graphics graphic)
        {
            Pen pen= new Pen(Brushes.Black,3);
            graphic.DrawRectangle(pen, x - 2, y - 2, 2, 2);
            graphic.DrawRectangle(pen, x+width - 1,y-2, 2,2);
            graphic.DrawRectangle(pen, x - 2, y + height - 2, 2, 2);
            graphic.DrawRectangle(pen, x + width - 1, y + height - 2, 2, 2);
        }
        public bool IsMouseOver(int X, int Y)
        {
            if (IsElementInRange(X, Y))
            {
                isMouseOver = true;
            }
            else
            {
                isMouseOver = false;
            }
            if (isSelected) { isMouseOver = false; }
            return isMouseOver;
        }

        public bool IsSelected(int X, int Y)
        {
            if (IsElementInRange(X, Y))
            {
                isMouseOver = false;
                isSelected = true;
            }
            else
            {
                isSelected = false;
            }
            return isSelected;
        }

        public bool IsElementInRange(int X, int Y)
        {
            if ((X >= this.x) && (X <= this.width + x) && (Y >= this.y) && (Y <= this.y + height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool getPreviousMouseOverState()
        {
            return isMouseOver;
        }
        public bool getPreviousSelectedState()
        {
            return isSelected;
        }

        public bool Move(int XX, int YY)
        {
            x = XX;
            y = YY;
            if ((XX != 0) && (YY != 0)) { return true; } else { return false; }
        }
        public void ClearMouseOverState()
        {
            isMouseOver = false;
        }
        public void ClearSelectedState()
        {
            isSelected = false;
        }

        public void Save(COMSEntities context)
        {

            if (this.obj_id != Guid.Empty) //database obj
            {
                Step step = context.Steps.Where(s => s.stepId.Equals(this.obj_id)).SingleOrDefault();

                if (step == null)
                {
                    return;
                }

                step.stepId = this.obj_id;
                step.name = this.Title;
                step.description = this.Description == null ? "" : this.Description;
                step.instruction = this.WorkInstruction == null ? "" : this.WorkInstruction;
                step.note = this.Notes == null ? "" : this.Notes;
                step.x = this.x;
                step.y = this.y;
                step.isActive = this.isActive;
                step.isStep = this.isStep;
                step.isBegin = this.isBegin;
                step.updated_by = "workflow_app";
                step.updated_date = DateTime.Now;

                COMSdbEntity.Formula StepFormula = null;

                if (step.Formulae.Count > 0)
                {
                    StepFormula = step.Formulae.First();
                    StepFormula.coef1 = this.Formula.coef1;
                    StepFormula.coef2 = this.Formula.coef2;
                    StepFormula.coef3 = this.Formula.coef3;
                    StepFormula.coef4 = this.Formula.coef4;
                    StepFormula.formula1 = this.Formula.strFormula;

                    StepFormula.isactive = true;
                    StepFormula.created_by = "system";
                    StepFormula.created_date = DateTime.Now;

                }
                else
                {
                    StepFormula = new COMSdbEntity.Formula();
                    StepFormula.coef1 = this.Formula.coef1;
                    StepFormula.coef2 = this.Formula.coef2;
                    StepFormula.coef3 = this.Formula.coef3;
                    StepFormula.coef4 = this.Formula.coef4;
                    StepFormula.formula1 = this.Formula.strFormula;

                    StepFormula.isactive = true;
                    StepFormula.created_by = "system";
                    StepFormula.created_date = DateTime.Now;
                    StepFormula.formulaId = Guid.NewGuid();

                    step.Formulae.Add(StepFormula);
                }


            }
            else //new obj
            {
                if (this.isActive)
                {
                    Step step = new Step();

                    step.workflowId = this.workflowid;
                    step.stepId = this.display_id;
                    step.name = this.Title;
                    step.description = this.Description == null ? "" : this.Description;
                    step.instruction = this.WorkInstruction == null ? "" : this.WorkInstruction;
                    step.note = this.Notes == null ? "" : this.Notes;
                    step.x = this.x;
                    step.y = this.y;
                    step.isActive=this.isActive;
                    step.isStep = this.isStep;
                    step.isBegin = this.isBegin;
                    step.created_by = "workflow_app";
                    step.created_date = DateTime.Now;
                    

                    COMSdbEntity.Formula StepFormula = new COMSdbEntity.Formula();
                    StepFormula.isactive = true;

                    StepFormula.coef1 = this.Formula.coef1;
                    StepFormula.coef2 = this.Formula.coef2;
                    StepFormula.coef3 = this.Formula.coef3;
                    StepFormula.coef4 = this.Formula.coef4;
                    StepFormula.formula1 = this.Formula.strFormula;

                    StepFormula.created_by = "system";
                    StepFormula.created_date = DateTime.Now;
                    StepFormula.formulaId = Guid.NewGuid();

                    step.Formulae.Add(StepFormula);

                    context.Steps.AddObject(step);
                }
            }

        }
        
        public void ChangedToDBObject()
        {
            this.obj_id = this.display_id;
        }

        public void SetFormula(formula Formula)
        {
            this.Formula = Formula;
        }
        public formula GetFormula()
        {
            return this.Formula;
        }
    }

}
