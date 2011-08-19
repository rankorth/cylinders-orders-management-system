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
        private Point point1_;
        private Point point2_;
        private String title_;

        private Pen penBlack_ = new Pen(Color.Black);
        private Font fontArial_ = new Font("Arial", 10);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="title"></param>
        public DrawingBlock(int top, int left, String title)
        {
            //g_ = g;
            point1_ = new Point(left - HALF_WIDTH, top - HALF_HEIGHT);
            point2_ = new Point(left + HALF_WIDTH, top + HALF_HEIGHT);
            rect_ = new Rectangle(left - HALF_WIDTH, top - HALF_HEIGHT, WIDTH, HEIGHT);
            title_ = title;
        }

        /// <summary>
        /// Draws the block with all the relevant info
        /// </summary>
        public void drawBlock(Graphics g)
        {
            g.DrawLine(penBlack_, point1_, point2_);
            g.DrawRectangle(penBlack_, rect_);
            g.DrawString(title_, fontArial_, Brushes.Black, new PointF(point1_.X, point1_.Y+HEIGHT));
        }
    }
}
