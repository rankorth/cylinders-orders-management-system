using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;



namespace WorkflowManagement
{
    public enum ConnectorState
    {
        Normal = 0,
        MouseOver = 1,
        Selected = 2
    }

    public enum ConnectionZone
    { //first drawn block _ later drawn block 
        Left_Left = 0,
        Right_Right = 1,
        Top_Top = 2,
        Bottom_Bottom = 3,
        Right_Left = 4,
        Left_Right = 5,
        Top_Bottom = 6,
        Bottom_Top = 7,
        None = 8
    }


    public  class Connector
    {
         public Block block1 {get ; set; }
         public Block block2{get ; set; }
         Point toPoint = new Point(); Point fromPoint = new Point();
         public ConnectorState Status = ConnectorState.Normal;
         Rectangle bounding_box=new Rectangle();
         static int line_to_point_tolerance = 3;
         public bool isLeftToRight = true;

         public Connector(Block BelowBlock, Block TopBlock, bool isLeftToRight)
         {
             block1 = BelowBlock; block2 = TopBlock; this.isLeftToRight = isLeftToRight;
         }
        public  void Draw( ConnectorState State,Graphics graphic)
        {
 
            Point[] PolyPoints = new Point[3] ;
            Point p = new Point();
            int Direction = +1;

            switch (DetermineConZone())
            {
                case ConnectionZone.Left_Left:
                    toPoint     = new Point(block2.x, block2.y + block2.height / 2); //Block2's left 
                    fromPoint = new Point(block1.x, block1.y + block1.height / 2);
                    p = toPoint;
                    if (!isLeftToRight)
                    {
                        p = fromPoint;
                        Direction = -1;
                    }
                     p.X = p.X - 2;
                    PolyPoints[0] = p;
                    PolyPoints[1] = new Point(p.X - 6 * Direction, p.Y - 6);
                    PolyPoints[2] = new Point(p.X - 6 * Direction, p.Y + 6);
                    p.X -= 6;

                    break;
                case ConnectionZone.Right_Right:
                    toPoint     = new Point(block2.width + block2.x, block2.y + block2.height / 2); //Block2's Right 
                    fromPoint   = new Point(block1.width + block1.x, block1.y + block1.height / 2); 
                    p = toPoint;
                    if (!isLeftToRight)
                    {
                        p = fromPoint;
                        Direction = -1;
                    }
                    p.X = p.X + 1;
                    PolyPoints[0] = p;
                    PolyPoints[1] = new Point(p.X + 6 * Direction, p.Y - 6);
                    PolyPoints[2] = new Point(p.X + 6 * Direction, p.Y + 6);
                    p.X += 6;
                    break;
                case ConnectionZone.Bottom_Bottom:
                    toPoint     = new Point(block2.width / 2 + block2.x, block2.y + block2.height); //Block2's bottom 
                    fromPoint   = new Point(block1.width / 2 + block1.x, block1.y + block1.height); 
                    p = toPoint;
                    if (!isLeftToRight)
                    {
                        p = fromPoint;
                        Direction = -1;
                    }
                    p.Y = p.Y + 2;
                    PolyPoints[0] = p;
                    PolyPoints[1] = new Point(p.X + 6, p.Y + 6 * Direction);
                    PolyPoints[2] = new Point(p.X - 6, p.Y + 6 * Direction);
                    p.Y += 6;
                    break;
                case ConnectionZone.Top_Top:
                    toPoint     = new Point(block2.width / 2 + block2.x, block2.y); //Block2's top 
                    fromPoint   = new Point(block1.width / 2 + block1.x, block1.y);
                    p = toPoint;
                    if (!isLeftToRight)
                    {
                        p = fromPoint;
                        Direction = -1;
                    }
                    p.Y = p.Y - 2;
                    PolyPoints[0] = toPoint;
                    PolyPoints[1] = new Point(p.X + 6, p.Y - 6 * Direction);
                    PolyPoints[2] = new Point(p.X - 6, p.Y - 6 * Direction);
                    p.Y -= 6;
                    break;
                case ConnectionZone.Left_Right:
                    fromPoint = new Point(block1.x, block1.y + block1.height / 2);
                    toPoint     = new Point(block2.width + block2.x, block2.y + block2.height / 2); //Block2's Right 
                    p = toPoint;
                    if (!isLeftToRight)
                    {
                        p = fromPoint;
                        Direction = -1;
                    }
                    p.X = p.X + 1;
                    PolyPoints[0] = p;
                    PolyPoints[1] = new Point(p.X + 6 * Direction, p.Y - 6);
                    PolyPoints[2] = new Point(p.X + 6 * Direction, p.Y + 6);
                    p.X += 6;
                    break;
                case ConnectionZone.Right_Left:
                    fromPoint = new Point(block1.width + block1.x, block1.y + block1.height / 2); 
                    toPoint     = new Point(block2.x, block2.y + block2.height / 2); //Block2's left
                    p = toPoint;
                    if (!isLeftToRight)
                    {
                        p = fromPoint;
                        Direction = -1;
                    }
                    p.X = p.X - 2;
                    PolyPoints[0] = p;
                    PolyPoints[1] = new Point(p.X - 6 * Direction, p.Y - 6);
                    PolyPoints[2] = new Point(p.X - 6 * Direction, p.Y + 6);
                    p.X -= 6;
                    break;
                case ConnectionZone.Top_Bottom:
                    fromPoint = new Point(block1.width / 2 + block1.x, block1.y);
                    toPoint     = new Point(block2.width / 2 + block2.x, block2.y + block2.height); //Block2's bottom
                    p = toPoint;
                    if (!isLeftToRight)
                    {
                        p = fromPoint;
                        Direction = -1;
                    }
                    p.Y = p.Y + 2;
                    PolyPoints[0] = p;
                    PolyPoints[1] = new Point(p.X + 6, p.Y + 6 * Direction);
                    PolyPoints[2] = new Point(p.X - 6, p.Y + 6 * Direction);
                    p.Y += 6;
                    break;
                case ConnectionZone.Bottom_Top:
                    fromPoint = new Point(block1.width / 2 + block1.x, block1.y + block1.height); 
                    toPoint     = new Point(block2.width / 2 + block2.x, block2.y); //Block2's top 
                    p = toPoint;
                    if (!isLeftToRight)
                    {
                        p = fromPoint;
                        Direction = -1;
                    }
                    p.Y = p.Y - 2;
                    PolyPoints[0] = p;
                    PolyPoints[1] = new Point(p.X + 6, p.Y - 6 * Direction);
                    PolyPoints[2] = new Point(p.X - 6, p.Y - 6 * Direction);
                    p.Y -= 6;
                    break;
            }
            
            graphic.DrawPolygon(Pens.Black,PolyPoints);
            graphic.FillPolygon(Brushes.BlueViolet, PolyPoints);

            Pen linePen=new Pen(Brushes.Black,1);
            if (Status == ConnectorState.MouseOver)
            {
                linePen = new Pen(Brushes.DarkOrange, 2);
            }
            else if (Status == ConnectorState.Selected)
            {
                linePen = new Pen(Brushes.Red, 2);
            }
            graphic.DrawLine(linePen, fromPoint, toPoint);

            RectangleConverter a = new RectangleConverter();

            int x1 = fromPoint.X;
            int y1 = fromPoint.Y;
            int x2 = toPoint.X;
            int y2 = toPoint.Y;
            int tmp;

            if (x1 > x2) { tmp = x1; x1 = x2; x2 = tmp; }
            if (y1 > y2) { tmp = y1; y1 = y2; y2 = tmp; }

            bounding_box = new Rectangle(x1, y1, x2 - x1, y2 - y1);


        }

        private  ConnectionZone DetermineConZone()
        {
            ConnectionZone ConZone = check_inner_zone();
            if (ConZone != ConnectionZone.None) { return ConZone; }

            return ConZone = check_outer_zone();
        }

        private  ConnectionZone check_inner_zone()
        {
            int result = 0;
            ConnectionZone ConZon;
            Point point;
            int R_top = 0;
            int R_bottom = 0;
            int R_left = 0;
            int R_right = 0;

            point = new Point(block2.width / 2 + block2.x, block2.y); //Block2's top 
            if (isPoint_in_block(block1, point))
            {
                //R_top = (int)Math.Sqrt((double)(Math.Abs(point.X - (block1.x + (block1.width / 2))) ^ 2 + Math.Abs(point.Y - block1.y) ^ 2));
                R_top = Math.Abs(point.Y - block1.y);
            }

            point = new Point(block2.width / 2 + block2.x, block2.y + block2.height); //Block2's bottom 
            if (isPoint_in_block(block1, point))
            {
                //R_bottom = (int)Math.Sqrt((double)(Math.Abs(point.X - (block1.x + (block1.width / 2))) ^ 2 + Math.Abs(point.Y - block1.y + block1.height) ^ 2));
                R_bottom = Math.Abs(point.Y - ( block1.y+block1.height));
            }

            point = new Point(block2.x, block2.y + block2.height / 2); //Block2's left 
            if (isPoint_in_block(block1, point))
            {
                //R_left = (int)Math.Sqrt((double)(Math.Abs(point.X - block1.x) ^ 2 + Math.Abs(point.Y - block1.y + block1.height / 2) ^ 2));
                R_left = Math.Abs(point.X- block1.x);
            }

            point = new Point(block2.width + block2.x, block2.y + block2.height / 2); //Block2's Right 
            if (isPoint_in_block(block1, point))
            {
                //R_right = (int)Math.Sqrt((double)(Math.Abs(point.X - (block1.x + block1.width)) ^ 2 + Math.Abs(point.Y - block1.y + block1.height / 2) ^ 2));
                R_right = Math.Abs(point.X - ( block1.x + block1.width));
            }

            R_top       = Math.Abs(R_top);
            R_bottom    = Math.Abs(R_bottom);
            R_left      = Math.Abs(R_left);
            R_right     = Math.Abs(R_right);
            result = R_top;
            ConZon = ConnectionZone.Top_Top;
            if (result < R_bottom)  { result = R_bottom; ConZon = ConnectionZone.Bottom_Bottom; }
            if (result < R_left)    { result = R_left; ConZon = ConnectionZone.Left_Left; }
            if (result < R_right)   { result = R_right; ConZon = ConnectionZone.Right_Right; }

            if (result <= 0) { ConZon = ConnectionZone.None; }
            return ConZon;
        }

        private  bool isPoint_in_block(Block block, Point point)
        {
            if ((point.X > block.x) && (point.X < block.x + block.width) &&
                (point.Y > block.y) && (point.Y < block.y + block.height))
            {
                return true;
            }
            return false;
        }

        private  ConnectionZone check_outer_zone()
        {
            double result = 0;
            ConnectionZone ConZon;
            Point point;
            double R_top = 0;
            double R_bottom = 0;
            double R_left = 0;
            double R_right = 0;
            
            point = new Point(block2.width / 2 + block2.x, block2.y); //Block2's top 
            R_top = Math.Sqrt((double)(Math.Abs(point.X - (block1.x + block1.width / 2)) ^ 2 + Math.Abs(point.Y - (block1.y + block1.height)) ^ 2));
            

            point = new Point(block2.width / 2 + block2.x, block2.y + block2.height); //Block2's bottom 
            R_bottom = (int)Math.Sqrt((double)(Math.Abs(point.X - (block1.x + block1.width / 2)) ^ 2 + Math.Abs(point.Y - (block1.y )) ^ 2));

            point = new Point(block2.x, block2.y + block2.height / 2); //Block2's left 
            R_left = Math.Sqrt((double)(Math.Abs(point.X - (block1.x+block1.width )) ^ 2 + Math.Abs(point.Y - (block1.y + block1.height/2)) ^ 2));

            point = new Point(block2.width + block2.x, block2.y + block2.height / 2); //Block2's Right 
            R_right = Math.Sqrt((double)(Math.Abs(point.X - (block1.x ) )^ 2 + Math.Abs(point.Y - (block1.y + block1.height/2)) ^ 2));

            R_top       = Math.Abs(R_top);
            R_bottom    = Math.Abs(R_bottom);
            R_left      = Math.Abs(R_left);
            R_right     = Math.Abs(R_right);
            result = R_top;
            ConZon = ConnectionZone.Bottom_Top;
            if (result > R_bottom)  { result = R_bottom; ConZon = ConnectionZone.Top_Bottom; }
            if (result > R_left)    { result = R_left; ConZon = ConnectionZone.Right_Left; }
            if (result > R_right)   { result = R_right; ConZon = ConnectionZone.Left_Right; }

            if (result <= 0) { ConZon = ConnectionZone.None; }
            return ConZon;
        }

        private bool isPointInRect(int x, int y)
        {
            return bounding_box.IntersectsWith(new Rectangle(x - 2, y - 2, 4, 4));
        }

        public bool isMouseOver(int x, int y)
        {
            if (Status == ConnectorState.Selected)
            {
                return false;
            }
            return isPointOnLine(x, y);
        }
        public bool isMouseSelected(int x, int y)
        {
            bool isSelected = false;
            if (isPointOnLine(x, y))
            {
                Status = ConnectorState.Selected;
                isSelected = true;
            }
            return isSelected;
        }
        private bool isPointOnLine(int x, int y)
        {
            bool result = false;
            double con_slope;
            double predit_y;
            try
            {
                if (isPointInRect(x, y))
                {
                    con_slope = ((double)fromPoint.Y - (double)toPoint.Y) / ((double)fromPoint.X - (double)toPoint.X);
                    predit_y = con_slope * (x - fromPoint.X) + fromPoint.Y;
                    if (Math.Abs(predit_y - y) < line_to_point_tolerance)
                    {
                        result = true;
                    }
                }
            }
            catch
            {
            }
            return result;
        }
    }
}
