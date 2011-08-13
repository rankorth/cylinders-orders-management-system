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
        private const int WIDTH = 100;
        private const int HEIGHT = 60;
        
        private Graphics g_;
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
        public DrawingBlock(Graphics g, int top, int left, String title)
        {
            g_ = g;
            point1_ = new Point(left, top);
            point2_ = new Point(left + WIDTH, top + HEIGHT);
            rect_ = new Rectangle(left, top, WIDTH, HEIGHT);
            title_ = title;
        }

        /// <summary>
        /// Draws the block with all the relevant info
        /// </summary>
        public void drawBlock()
        {
            g_.DrawLine(penBlack_, point1_, point2_);
            g_.DrawRectangle(penBlack_, rect_);
            g_.DrawString(title_, fontArial_, Brushes.Black, new PointF(point1_.X, point1_.Y+HEIGHT));
        }
    }
}
