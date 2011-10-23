using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WorkflowManagement
{
    public class Block
    {
        private Guid display_id = Guid.NewGuid();
        public  Guid obj_id = Guid.Empty;
        public int x { get; set; }
        public int y { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public string WorkInstruction { get; set; }
        public string Notes { get; set; }


        public int width { get; set; }
        public int height { get; set; }
        private bool isSelected = false;
        private bool isMouseOver = false;

        public Guid ID
        {
            get
            {
                return this.display_id;
            }
        }
        public void CreatefromDB(Guid ID, int x, int y, string Title,
                                 string Desc, string WorkInstruct, string Notes)
        {
            this.obj_id = ID;
            this.display_id = ID;
            this.x      = x;
            this.y      = y;
            this.Title  = Title;
            this.Description        = Desc;
            this.WorkInstruction    = WorkInstruct;
            this.Notes              = Notes;
        }
        public void Create(int x, int y, string Title)
        {
            this.x = x;
            this.y = y;
            this.Title = Title;
        }
        public void Draw(Graphics graphic)
        {
            //graphic.PageUnit = GraphicsUnit.Display;
            Font sFont =  new Font("Arial", 10);
            Pen retPen = new Pen(Brushes.Black, 1);
            Brush retFill = Brushes.White;
            if (isMouseOver) { retPen = new Pen(Brushes.Orange, 2); retFill = Brushes.LightYellow; }
            if (isSelected) { retPen = new Pen(Brushes.Black, 1); retFill = Brushes.Orange; }
            SizeF sSize = graphic.MeasureString(Title, sFont);
            width = Convert.ToInt32( sSize.Width ) + 2;
            height =Convert.ToInt32( sSize.Height) + 2;
            Rectangle block = new Rectangle(x, y, width, height);
            graphic.FillRectangle(retFill, block); 
            graphic.DrawRectangle(retPen, block);
            
            graphic.DrawString(Title, sFont, Brushes.Black, new Point(x + 2, y + 2));

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
    }

}
