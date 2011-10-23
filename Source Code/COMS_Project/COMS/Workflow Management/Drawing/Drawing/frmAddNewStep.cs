using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkflowManagement
{
    public partial class frmAddNewStep : Form
    {
        public string StepName = "";
        public frmAddNewStep()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            StepName = txtStepName.Text.Trim();
            if(String.IsNullOrEmpty(StepName))
            {
                MessageBox.Show("Step Name can not be empty","Warning!");
            }else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StepName = "";
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
