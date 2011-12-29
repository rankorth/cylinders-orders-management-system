using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.EntityClient;
using System.Data.Entity;

using COMSdbEntity;
using BusinessLogics;

namespace Example
{
    public partial class Form1 : Form
    {
        private MainController mainCtrl = new MainController();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}
