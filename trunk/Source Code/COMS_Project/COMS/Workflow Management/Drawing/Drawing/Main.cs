using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Drawing;

namespace WorkflowManagement
{
    public partial class Main : Form
    {
        private int childFormNumber = 0;
        //private int currentActiveChildNo=-1;
        private Block currentWorkflowActivity = null;
        private WorkflowDesigner currentWorkflowDesignerWindow = null;

        public Main()
        {
            InitializeComponent();
        }
        private void NewWorkflowDocument()
        {
            WorkflowDesigner childForm = new WorkflowDesigner();
            childForm.MdiParent = this;
            childForm.Text = "Untitled - " + childFormNumber++;
            childForm.Show();
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            NewWorkflowDocument();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenWorkflow();
        }

        private void UnderConstruction()
        {
            MessageBox.Show(this, "Under construction!", "Sorry!");
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WorkflowDesigner)ActiveMdiChild).SaveDocumentAs();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (WorkflowDesigner childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        public void setPropertyEnable(bool Enable)
        {
            pnlProperties.Enabled = Enable;
            currentWorkflowActivity = null;
        }
        public void ResetProperty(Block WorkflowActivity)
        {


            if (WorkflowActivity == null)
            {
                txtName.Text = "";
                txtDescription.Text = "";
                txtWorkInstruction.Text = "";
                txtNotes.Text = "";

                txtCoef1.Text = "";
                txtCoef2.Text = "";
                txtCoef3.Text = "";
                txtCoef4.Text = "";

                return;
            }
            if (WorkflowActivity.isStep)
            {
                txtName.Text = WorkflowActivity.Title;
                txtDescription.Text = WorkflowActivity.Description;
                txtWorkInstruction.Text = WorkflowActivity.WorkInstruction;
                txtNotes.Text = WorkflowActivity.Notes;

                txtCoef1.Text = WorkflowActivity.GetFormula().coef1.ToString();
                txtCoef2.Text = WorkflowActivity.GetFormula().coef2.ToString();
                txtCoef3.Text = WorkflowActivity.GetFormula().coef3.ToString();
                txtCoef4.Text = WorkflowActivity.GetFormula().coef4.ToString();


                currentWorkflowActivity = WorkflowActivity;
                currentWorkflowDesignerWindow = (WorkflowDesigner)ActiveMdiChild;
            }
            else
            {
                pnlProperties.Enabled = false;
                txtName.Text = "";
                txtDescription.Text = "";
                txtWorkInstruction.Text = "";
                txtNotes.Text = "";

                txtCoef1.Text = "";
                txtCoef2.Text = "";
                txtCoef3.Text = "";
                txtCoef4.Text = "";

                return;
            }
        }



        private void PropertyChanged(object sender, EventArgs e)
        {
            if (currentWorkflowActivity != null)
            {
                currentWorkflowActivity.Title = txtName.Text.Trim();
                currentWorkflowActivity.Description = txtDescription.Text.Trim();
                currentWorkflowActivity.WorkInstruction = txtWorkInstruction.Text.Trim();
                currentWorkflowActivity.Notes = txtNotes.Text.Trim();

                txtCoef1.Text = txtCoef1.Text.Trim().Length == 0 ? "0" : txtCoef1.Text.Trim().Replace(" ","");
                txtCoef2.Text = txtCoef2.Text.Trim().Length == 0 ? "0" : txtCoef2.Text.Trim().Replace(" ", "");
                txtCoef3.Text = txtCoef3.Text.Trim().Length == 0 ? "0" : txtCoef3.Text.Trim().Replace(" ", "");
                txtCoef4.Text = txtCoef4.Text.Trim().Length == 0 ? "0" : txtCoef4.Text.Trim().Replace(" ", "");

                formula Formula = new formula();
                Formula.coef1 = Convert.ToInt32(txtCoef1.Text.Trim());
                Formula.coef2 = Convert.ToInt32(txtCoef2.Text.Trim());
                Formula.coef3 = Convert.ToInt32(txtCoef3.Text.Trim());
                Formula.coef4 = Convert.ToInt32(txtCoef4.Text.Trim());
                currentWorkflowActivity.SetFormula(Formula);


                currentWorkflowDesignerWindow.isDocSaved = false;
                currentWorkflowDesignerWindow.RePaint();

                
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ((WorkflowDesigner)ActiveMdiChild).SaveDocument();
            }
            else
            {
                MessageBox.Show("Please select a document to save.", "Warning");
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            UnderConstruction();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WorkflowDesigner)ActiveMdiChild).SaveDocument();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox About = new AboutBox();
            About.ShowDialog(this);
        }

        private void OpenWorkflow()
        {
            OpenDialog Open = new OpenDialog();

            if (Open.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (WorkflowDesigner wd in this.MdiChildren)
                {
                    if (wd.WorkflowID.Equals(Open.workflowId))
                    {
                        //MessageBox.Show("This workflow has already been opened.", "Warning");
                        wd.Activate();
                        return;
                    }
                }

                WorkflowDesigner childForm = new WorkflowDesigner();
                childForm.MdiParent = this;
                childForm.Text = Open.DocName;
                childForm.DocDescription = Open.DocDescription;
                childForm.DocName = Open.DocName;
                childForm.WorkflowID = Open.workflowId;
                childForm.Show();
                //call open workflow rotine

            }
        }
    }
}
