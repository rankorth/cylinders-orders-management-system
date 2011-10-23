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
    public partial class SaveDialog : Form
    {
        public string WorkflowName = string.Empty;
        public string WorkflowDescription = string.Empty;

        public SaveDialog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show(this,"Workflow Name can not be blank","Warning");
            }else
            {
                Save();
            }
        }

        private void Save()
        {
            try
            {
                WorkflowName = txtName.Text.Trim();
                WorkflowDescription = txtDescription.Text.Trim();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch
            {
                DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
