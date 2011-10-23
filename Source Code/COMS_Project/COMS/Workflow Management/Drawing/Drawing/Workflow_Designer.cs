using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkflowManagement;

namespace Drawing
{
    public partial class WorkflowDesigner : Form
    {
        Canvas Drawing_Canvas;
        string NewStep = "";
        bool isAddingNewStep = false;
        bool isAddingNewConnection = false;
        private bool isNewDoc = true;
        private bool isActiveDocument = false;
        public bool isDocSaved=false;

        public string DocName = "";
        public string DocDescription = "";

        public bool IsNewDocument
        {
            get { return isNewDoc; }
        }
        
        public void SaveDocumentAs()
        {
            SaveDialog saveDialog = new SaveDialog();
            if (saveDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SendToServer();
                UpdateDocInfo(saveDialog.WorkflowName, saveDialog.WorkflowDescription);
                MessageBox.Show(this, "Document saved successfully.", "Document Saved", MessageBoxButtons.OK);
                isNewDoc = false;
                isDocSaved = true;
            }
            saveDialog.Dispose();
        }
        public WorkflowDesigner()
        {
            InitializeComponent();
        }
        public void OpenWorkflow(Guid Workflow_ID)
        {
            //write retrival rotine
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Drawing_Canvas = new Canvas(pnlCanvas.Size);
        }


        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //Auto resize drawing canvas
                // if(pnlCanvas.Width<= e.X+100) pnlCanvas.Width = e.X+ 100;
                // if(pnlCanvas.Height<=e.Y+100)  pnlCanvas.Height = e.Y+100;

                Drawing_Canvas.MouseDrag(e.X, e.Y);
                isDocSaved = false;
            }
            else
            {
                Drawing_Canvas.MouseOver(e.X, e.Y);
            }
            PaintDrawing();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing_Canvas.Select(e.X, e.Y);
            PaintDrawing();
            UpdatePropertyPanel();
        }



        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Drawing_Canvas.MouseUp();
        }

        private void tblAddNewStep_Click(object sender, EventArgs e)
        {
            frmAddNewStep step = new frmAddNewStep();
            if (step.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                NewStep = step.StepName;
                pnlCanvas.Cursor = Cursors.Cross;
                isAddingNewStep = true;
                tblMenu.Enabled = false;
            }
        }

        public void RePaint()
        {
            PaintDrawing();
        }
        private void PaintDrawing()
        {
            Point p = pnlCanvas.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            Drawing_Canvas.Paint(pnlCanvas.CreateGraphics(), p.X, p.Y);
            if (Drawing_Canvas.isElementSelected)
            {
                tblDelete.Visible = true;
            }
            else
            {
                tblDelete.Visible = false;
            }
        }

        private void UpdatePropertyPanel()
        {
            if (!isActiveDocument) { return; }
            if (!Drawing_Canvas.isElementSelected)
            {
                ((Main)this.MdiParent).setPropertyEnable(false); 
                ((Main)this.MdiParent).ResetProperty(null);
                return;
            }
            if (Drawing_Canvas.isConnectorSelected)
            {
                ((Main)this.MdiParent).setPropertyEnable(false);
                ((Main)this.MdiParent).ResetProperty(null);
            }
            else
            {
                ((Main)this.MdiParent).setPropertyEnable(true);
                ((Main)this.MdiParent).ResetProperty(Drawing_Canvas.SelectedWorkflowActivity);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            PaintDrawing();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isAddingNewStep)
            {
                pnlCanvas.Cursor = Cursors.Default;
                tblMenu.Enabled = true;
                isAddingNewStep = false;
                if (!string.IsNullOrEmpty(NewStep))
                {
                    Drawing_Canvas.Create_Block(e.X, e.Y, NewStep, -1, -1);
                    isDocSaved = false;
                }
            }

            if (Drawing_Canvas.CanvasStatus != CanvasState.None && isAddingNewConnection)
            {
                pnlCanvas.Cursor = Cursors.Cross;
                isAddingNewConnection = true;
            }
            else
            {
                pnlCanvas.Cursor = Cursors.Default;
                isAddingNewConnection = false;
                tblMenu.Enabled = true;
            }


        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void tblAddConnector_Click(object sender, EventArgs e)
        {
            pnlCanvas.Cursor = Cursors.Cross;
            tblMenu.Enabled = false;
            isAddingNewConnection = true;
            Drawing_Canvas.AddConnector();
            isDocSaved = false;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void pnlContainer_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void pnlContainer_Resize(object sender, EventArgs e)
        {

        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tblDelete_Click(object sender, EventArgs e)
        {
            Drawing_Canvas.DeleteSelectedElement();
            isDocSaved = false;

            PaintDrawing();
        }

        private void WorkflowDesigner_Activated(object sender, EventArgs e)
        {
            isActiveDocument = true;
            UpdatePropertyPanel();
        }

        private void WorkflowDesigner_Deactivate(object sender, EventArgs e)
        {
            isActiveDocument = false;
        }

        private void WorkflowDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            check_and_save_doc();
            
        }
        private void check_and_save_doc()
        {
            if (!isDocSaved)
            {
                if (MessageBox.Show(this, "Do you want to save this document?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveDocument();
                }
            }
        }

        public void SaveDocument()
        {
           
            if (isNewDoc)
            {
                SaveDocumentAs();
            }
            else
            {
                SendToServer();
                MessageBox.Show(this, "Document saved successfully.", "Document Saved", MessageBoxButtons.OK);
                isNewDoc = false;
                isDocSaved = true;
            }
        }

        private void UpdateDocInfo(string Name,string Description)
        {
            DocName = Name;
            DocDescription = Description;
            this.Text = DocName;

        }

        private void SendToServer()
        {
            //***write code to send workflow data to server
            try
            {
            }
            catch
            {
            }
        }
    }
}
