using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

// 13 Aug 2011
// Author: Alvin Chang
// Used for storing the drawing information for each activity block

namespace WorkflowApplication
{
    public class DrawingBlock
    {
        private const int HALF_WIDTH = 50;
        private const int HALF_HEIGHT = 30;
        private const int WIDTH = HALF_WIDTH * 2;
        private const int HEIGHT = HALF_HEIGHT * 2;
        
        //private Graphics g_;
        private Rectangle rect_;
        private int x_;
        private int y_;
        private Point point1_;
        private Point point2_;
        private String title_;
        private bool ismouseover_;

        private Pen penBlack_ = new Pen(Color.Black);
        private Pen penBlue_ = new Pen(Color.Blue);
        private Font fontArial_ = new Font("Arial", 10);

        public int X 
        {
            set { x_ = value; }
        }

        public int Y
        {
            set { y_ = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="title"></param>
        public DrawingBlock(int x, int y, String title)
        {
            //g_ = g;
            x_ = x;
            y_ = y;
            title_ = title;
            calculateParams(x, y);
            ismouseover_ = true;
        }

        private void calculateParams(int x, int y)
        {
            point1_ = new Point(x - HALF_WIDTH, y - HALF_HEIGHT);
            point2_ = new Point(x + HALF_WIDTH, y + HALF_HEIGHT);
            rect_ = new Rectangle(x - HALF_WIDTH, y - HALF_HEIGHT, WIDTH, HEIGHT);
        }

        /// <summary>
        /// Draws the block with all the relevant info
        /// </summary>
        public void drawBlock(Graphics g)
        {
            Pen pencolor = ismouseover_ ? penBlue_ : penBlack_;

            g.DrawLine(pencolor, point1_, point2_);
            g.DrawRectangle(pencolor, rect_);
            g.DrawString(title_, fontArial_, Brushes.Black, new PointF(point1_.X, point2_.Y));
        }

        /// <summary>
        /// Detects if mouse cursor is within the block
        /// </summary>
        /// <param name="x">int mouse x</param>
        /// <param name="y">int mouse y</param>
        /// <returns>true if mouse cursor is in block</returns>
        public bool detectBlock(int x, int y)
        {
            return ((point1_.X < x) && (x < point2_.X) && (point1_.Y < y) && (y < point2_.Y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isHighlighted"></param>
        /// <returns>true if value for ismouseover has changed</returns>
        public bool setHighlight(int x, int y)
        {
            bool isHighlighted = detectBlock(x, y);
            bool return_val = ismouseover_ != isHighlighted;
            ismouseover_ = isHighlighted;
            return return_val;
        }
    }
}
