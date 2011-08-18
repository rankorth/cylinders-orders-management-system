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
    public partial class FormStepProperties : Form
    {
        public FormStepProperties()
        {
            InitializeComponent();
        }

        // expose the textbox for reading
        public String StepName
        {
            get { return textBoxStepName.Text; }
        }
    }
}
