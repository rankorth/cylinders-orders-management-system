﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkflowApplication
{
    public partial class FormMain : Form
    {
        // declare for forms
        FormStepList frmStepList;
        FormWorkflowList frmWorkflowList;
       // FormAbout frmAbout;

        // private methods
        private void ShowWorkflowForm()
        {
            frmWorkflowList.Show();
            frmWorkflowList.BringToFront();
        }

        private void ShowStepForm()
        {
            frmStepList.Show();
            frmStepList.BringToFront();
        }

        private void ShowAboutForm()
        {
           // frmAbout.ShowDialog();
        }

        public FormMain()
        {
            InitializeComponent();

           // frmAbout = new FormAbout();

            frmWorkflowList = new FormWorkflowList();
            frmWorkflowList.MdiParent = this;
            frmStepList = new FormStepList();
            frmStepList.MdiParent = this;
        }

        // creates new workflow editor (leads from listofworkflows)
        public void createNewWorkflowEditorForm(String strWorkflowName)
        {
            FormWorkflowEditor frmWFEditor = new FormWorkflowEditor();
            frmWFEditor.MdiParent = this;
            frmWFEditor.Text += " - " + strWorkflowName;
            frmWFEditor.WorkflowName = strWorkflowName;
            frmWFEditor.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }
        
        private void workflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWorkflowForm();
        }

        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStepForm();
        }

        private void populateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // populate data
            ShowWorkflowForm();
            ShowStepForm();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutForm();
        }

    }
}
