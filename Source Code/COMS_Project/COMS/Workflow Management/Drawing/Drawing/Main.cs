using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Drawing;

using Microsoft.JScript;
using Microsoft.JScript.Vsa;


namespace WorkflowManagement
{
    public partial class Main : Form
    {
        public static bool isAuthenticated=false;
        public static VsaEngine _engine = VsaEngine.CreateEngine();
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
                txtFormula.Text = "";

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
                txtFormula.Text = WorkflowActivity.GetFormula().strFormula.ToString().Trim();


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
                txtFormula.Text = "";
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
                Formula.coef1 = System.Convert.ToInt32(txtCoef1.Text.Trim());
                Formula.coef2 = System.Convert.ToInt32(txtCoef2.Text.Trim());
                Formula.coef3 = System.Convert.ToInt32(txtCoef3.Text.Trim());
                Formula.coef4 = System.Convert.ToInt32(txtCoef4.Text.Trim());
                Formula.strFormula = txtFormula.Text;

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
            Login LoginDiag = new Login();
            if (isAuthenticated == false)
            {
                if (LoginDiag.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    isAuthenticated = true;
                }
                else
                {
                    isAuthenticated = false;
                    return;
                }
            }

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

        private void txtFormula_TextChanged(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text.Trim();
            if (txtFormula.Text.Length <= 0)
            {
                return;
            }
            if (!CheckFormula(txtFormula.Text.Trim()))
            {
                txtFormula.Focus();
                MessageBox.Show("Wrong formula. Please verify.");
            }
            PropertyChanged(sender, e);
        }

        public bool CheckFormula(string formula)
        {
            bool isCorrect = false;

            formula = formula.Replace('D', '1');
            formula = formula.Replace('S', '1');
            formula = formula.Replace('a', '1');
            formula = formula.Replace('b', '1');
            formula = formula.Replace('c', '1');
            formula = formula.Replace('d', '1');
            if (formula.Length == 0)
            {
                return true;
            }
            char lastchar = formula[formula.Length-1];
            if (lastchar.Equals('+') || lastchar.Equals('-') || lastchar.Equals('*') 
                || lastchar.Equals('/'))
            {
                formula = formula.Substring(0, formula.Length - 1);
            }



            try
            {
                double.Parse(Eval.JScriptEvaluate(formula, _engine).ToString());
                isCorrect=true;
            }
            catch
            {
                isCorrect=false;
            }
                return isCorrect;
        }

        private void txtFormula_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }
    }
}
