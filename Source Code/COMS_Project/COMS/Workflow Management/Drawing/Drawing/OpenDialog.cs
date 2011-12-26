using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMSdbEntity;
using System.Data.Entity;
using System.Data.EntityClient;

namespace WorkflowManagement
{
    public partial class OpenDialog : Form
    {
        public string DocName = "";
        public string DocDescription ="" ;
        public Guid workflowId = Guid.Empty;

        public OpenDialog()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgWorkflows.SelectedRows.Count > 0)
            {
                DocName = dgWorkflows.SelectedRows[0].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(DocName.Trim())) { DocName = "null"; }
                workflowId =(Guid) dgWorkflows.SelectedRows[0].Cells[1].Value;
            }
            
            if (!string.IsNullOrEmpty(DocName))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            else
            {
                MessageBox.Show(this, "Please select a workflow document to open", "Warning");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void OpenDialog_Load(object sender, EventArgs e)
        {
            COMSEntities context = new COMSEntities();

            IQueryable<Workflow> workflows = context.Workflows.Where(w => w.isactive==true);

            dgWorkflows.AutoGenerateColumns = false;

            dgWorkflows.DataSource = workflows;

            context.Dispose();
        }

        private void dgWorkflows_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
