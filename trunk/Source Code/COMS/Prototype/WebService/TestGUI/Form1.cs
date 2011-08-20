using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestGUI.WorkflowServiceRef;

namespace TestGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkflowClient WFclient = new WorkflowClient();

            // Use the 'client' variable to call operations on the service.
            MessageBox.Show(WFclient.saveWorkflow().ToString());
            // Always close the client.
            WFclient.Close();
        }
    }
}
