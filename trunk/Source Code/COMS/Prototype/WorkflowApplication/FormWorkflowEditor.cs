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
        private bool doTmpBlockDraw_ = false;       // false = don't draw
        ArrayList listOfBlocks_ = new ArrayList();

        public FormWorkflowEditor()
        {
            InitializeComponent();

            DrawingBlock dbk = new DrawingBlock(50, 30, "Printing");
            listOfBlocks_.Add(dbk);
            
            DrawingBlock dbk2 = new DrawingBlock(120, 120, "Engraving");
            listOfBlocks_.Add(dbk2);
        }


        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (DrawingBlock dbk in listOfBlocks_)
            {
                dbk.drawBlock(g);
            }

            DrawingBlock dbktmp = new DrawingBlock(tmpBlockPoint_.Y, tmpBlockPoint_.X, "Engraving");
            if (doTmpBlockDraw_) dbktmp.drawBlock(g);
        }

        private void panelDraw_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine(e.Data.GetDataPresent(DataFormats.StringFormat));
            doTmpBlockDraw_ = true;
            panelDraw.Refresh();
        }

        private void panelDraw_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Will trigger once mouse (with dragged item) goes into container area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelDraw_DragOver(object sender, DragEventArgs e)
        {
            //indexOfItemUnderMouseToDrop = listBox2.IndexFromPoint(listBox2.PointToClient(new Point(e.X, e.Y)));
            
            // enable drawing of tmpblock
            Console.WriteLine(e.Data.GetData(DataFormats.Text));
            Console.WriteLine(e.X.ToString() + "," + e.Y.ToString());
            Console.WriteLine(this.MdiParent.Location.X.ToString() + "," + this.MdiParent.Location.Y.ToString());
            Console.WriteLine(this.Location.X.ToString() + "," + this.Location.Y.ToString());
            Console.WriteLine(panelDraw.Location.X.ToString() + "," + panelDraw.Location.Y.ToString());

            // e.X -> entire screen offset
            // this.MdiParent.Location.X -> MdiParent offset
            // this.location.X -> mdi child window offset
            // to draw on g
            
            tmpBlockPoint_.X = e.X - this.MdiParent.Location.X - this.Location.X;
            tmpBlockPoint_.Y = e.Y - this.MdiParent.Location.Y - this.Location.Y - 110;
            panelDraw.Refresh();

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
    }
}
