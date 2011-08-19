using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WorkflowApplication
{
    public partial class FormWorkflowEditor : Form
    {
        private Point tmpBlockPoint_ = new Point(0, 0);  // used for drawing any drag and drop action
        private String tmpBlockText_ = "";
        private bool doTmpBlockDraw_ = false;       // false = don't draw
        ArrayList listOfBlocks_ = new ArrayList();

        public FormWorkflowEditor()
        {
            InitializeComponent();

            //DrawingBlock dbk = new DrawingBlock(80, 30, "Printing");
            //listOfBlocks_.Add(dbk);

            //DrawingBlock dbk2 = new DrawingBlock(120, 120, "Engraving");
            //listOfBlocks_.Add(dbk2);
        }

        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (DrawingBlock dbk in listOfBlocks_)
            {
                dbk.drawBlock(g);
            }

            DrawingBlock dbktmp = new DrawingBlock(tmpBlockPoint_.Y, tmpBlockPoint_.X, tmpBlockText_);
            if (doTmpBlockDraw_) dbktmp.drawBlock(g);
        }

        private void panelDraw_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine(e.Data.GetDataPresent(DataFormats.StringFormat));
            doTmpBlockDraw_ = true;
            panelDraw.Refresh();
        }

        /// <summary>
        /// Completed the drag and drop opeartion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelDraw_DragDrop(object sender, DragEventArgs e)
        {
            // add to the array list of drawing blocks (workflow)
            DrawingBlock dbk = new DrawingBlock(tmpBlockPoint_.Y, tmpBlockPoint_.X, tmpBlockText_);
            listOfBlocks_.Add(dbk);

            doTmpBlockDraw_ = false;
            panelDraw.Refresh();
        }

        /// <summary>
        /// Will trigger once mouse (with dragged item) goes into container area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelDraw_DragOver(object sender, DragEventArgs e)
        {
            //indexOfItemUnderMouseToDrop = listBox2.IndexFromPoint(listBox2.PointToClient(new Point(e.X, e.Y)));
            e.Effect = DragDropEffects.Copy;

            // enable drawing of tmpblock
            Console.WriteLine(e.Data.GetData(DataFormats.Text));
            Console.WriteLine(e.X.ToString() + "," + e.Y.ToString());
            //Console.WriteLine(this.MdiParent.Location.X.ToString() + "," + this.MdiParent.Location.Y.ToString());
            //Console.WriteLine(this.Location.X.ToString() + "," + this.Location.Y.ToString());
            //Console.WriteLine(toolStripContainer1.ContentPanel.Location.X.ToString() + "," + toolStripContainer1.ContentPanel.Location.Y.ToString());

            // e.X -> entire screen offset
            // this.MdiParent.Location.X -> MdiParent offset
            // this.location.X -> mdi child window offset
            // to draw on g

            // Calculate the startPoint by using the PointToScreen 
            // method.
            Point startPoint = panelDraw.PointToScreen(panelDraw.Location);
            Console.WriteLine(startPoint.X.ToString() + "," + startPoint.Y.ToString());

            tmpBlockPoint_.X = e.X - startPoint.X;
            tmpBlockPoint_.Y = e.Y - startPoint.Y;

            tmpBlockText_ = e.Data.GetData(DataFormats.Text).ToString();
            panelDraw.Refresh();

            toolStripCoord.Text = "(" + tmpBlockPoint_.X.ToString() + "," + tmpBlockPoint_.Y.ToString() + ")";

            // if  the MouseDown event set the DragDrop operation to be a move event
            // immediately delete the item.  This has the desirable effect of
            // deleting any duplicate strings that might have been moved into
            // listBox2
            if (e.Effect == DragDropEffects.Move) { // When moving an item within listBox2
                //listBox2.Items.Remove((string)e.Data.GetData(DataFormats.Text));
            }
        }

        private void panelDraw_DragLeave(object sender, EventArgs e)
        {
            // disable drawing of tmpblock
            doTmpBlockDraw_ = false;
        }

        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripCoord.Text = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
        }

    }
}
