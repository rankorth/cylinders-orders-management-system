using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkflowApplication
{
    public partial class FormStepList : Form
    {
        public FormStepList()
        {
            InitializeComponent();
        }

        private void FormStepList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }

        }

        private void toolStripButtonAddStep_Click(object sender, EventArgs e)
        {
            // add a new step
            FormStepProperties frmStepProp = new FormStepProperties();
            if (frmStepProp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // populate new Workflow object
                //Workflow wf = new Workflow();

                // refresh the workflow list
                listBoxSteps.Items.Add(frmStepProp.StepName);                
            }
        }

        private void listBoxSteps_MouseDown(object sender, MouseEventArgs e)
        {
            // starts a DoDragDrop operation with allowed effect  "Copy"
            //eventCount = eventCount + 1;  // increment event counter
            DateTime date = DateTime.Now; // get time of event

            int indexOfItem = listBoxSteps.IndexFromPoint(e.X, e.Y);
            if (indexOfItem >= 0 && indexOfItem < listBoxSteps.Items.Count)  // check that an string is selected
            {
                Console.WriteLine("Item selected:" + indexOfItem.ToString());
                // show the selection made in the bottom listBox3
                //listBox3.Items.Add("   " + eventCount.ToString() + ".1 ListBox1 Item Selected at MouseDown  was \"" + listBox1.Items[indexOfItem] + "\"");
                //listBox3.Items.Add("   " + eventCount.ToString() + ".2 DoDragDrop operation started from listBox1_MouseDown event! ");
                //listBox3.Items.Add("   " + eventCount.ToString() + ".2.1   DoDragDrop method's \"object data\" parameter is: " + (listBox1.Items[indexOfItem]).ToString() + " whose type is: " + listBox1.Items[indexOfItem].GetType());
                //listBox3.Items.Add("   " + eventCount.ToString() + ".2.1   DoDragDrop method's   DragDropEffects parameter is set to: " + DragDropEffects.Copy.ToString());

                // Set allowed DragDropEffect to Copy selected from DragDropEffects enumberation of None, Move, All etc.
                listBoxSteps.DoDragDrop(listBoxSteps.Items[indexOfItem], DragDropEffects.All);
            }
        }

        private void listBoxSteps_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            // This event is fired when there is a change in the keyboard or mouse button state
            // during a drag-and-drop operation.  This means that if the cursor is
            // moved,  this event is fired.  If the keyboard is pressed or if a 
            // change to a mouse button occurs(press or release), this even is fired. 
            // In other words, this event is fired alot!
            // For the purposes of the demo, if the mouse cursor  moves off Form1's boundaries
            // during DoDragDrop operation initiated by the  listBox2 mousedown event
            // the DoDragDrop operation initiated should be cancelled.

            // ( from VS. .NET Combined Collection Control.DoDragDrop documentation)
            // The screenOffset is used to account for any desktop bands 
            // that may be at the top or left side of the screen when 
            // determining when to cancel the drag drop operation.
            
            Point screenOffset = SystemInformation.WorkingArea.Location;

            ListBox lb = sender as ListBox;

            //if (lb != null)
            //{
            //    Form f = lb.FindForm();
            //    // Cancel the drag if the mouse moves off the form. The screenOffset
            //    // takes into account any desktop bands that may be at the top or left
            //    // side of the screen.
            //    if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
            //        ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
            //        ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
            //        ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom))
            //    {
            //        e.Action = DragAction.Cancel;
            //    }
            //}
        }

    }
}
