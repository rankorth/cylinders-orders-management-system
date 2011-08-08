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

    }
}
