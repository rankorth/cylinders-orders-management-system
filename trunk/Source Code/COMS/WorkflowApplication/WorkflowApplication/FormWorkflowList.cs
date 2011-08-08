using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Lessons learnt:
// - Able to open / close MDI windows UI framework
// - Achieve familiarity with .NET EntityObject Framework
// - Achieve familiarity with Drag-Drop functionality
// - Testing Web Service (not yet)

namespace WorkflowApplication
{
    public partial class FormWorkflowList : Form
    {
        public FormWorkflowList()
        {
            InitializeComponent();
        }

        private void FormWorkflowList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }

        }

        private void toolStripButtonAddWorkflow_Click(object sender, EventArgs e)
        {
            // add a new workflow
            FormWorkflowProperties frmWFProp = new FormWorkflowProperties();
            if (frmWFProp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // populate new Workflow object
                //Workflow wf = new Workflow();
                

                // refresh the workflow list
                listBoxWorkflows.Items.Add(frmWFProp.WorkflowName);
            }
        }

        private void listBoxWorkflows_DoubleClick(object sender, EventArgs e)
        {
            // check if item selected
            if (listBoxWorkflows.SelectedItems.Count >= 1)
            {
                //MessageBox.Show("test");
                ((FormMain)MdiParent).createNewWorkflowEditorForm(listBoxWorkflows.SelectedItem.ToString());
            }   // end if
        }
    }
}
