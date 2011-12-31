namespace Drawing
{
    partial class WorkflowDesigner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.tblMenu = new System.Windows.Forms.ToolStrip();
            this.tblAddNewStep = new System.Windows.Forms.ToolStripButton();
            this.tblAddNewCon = new System.Windows.Forms.ToolStripButton();
            this.tblDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbNextWorkflow = new System.Windows.Forms.ToolStripComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.tblMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanvas.Location = new System.Drawing.Point(3, 3);
            this.pnlCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(1049, 1049);
            this.pnlCanvas.TabIndex = 0;
            this.pnlCanvas.Click += new System.EventHandler(this.panel1_Click);
            this.pnlCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.pnlCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.pnlCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.pnlCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.pnlCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.pnlCanvas.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // tblMenu
            // 
            this.tblMenu.BackColor = System.Drawing.Color.Silver;
            this.tblMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tblMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tblAddNewStep,
            this.tblAddNewCon,
            this.tblDelete,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cmbNextWorkflow});
            this.tblMenu.Location = new System.Drawing.Point(0, 0);
            this.tblMenu.Name = "tblMenu";
            this.tblMenu.Padding = new System.Windows.Forms.Padding(0);
            this.tblMenu.Size = new System.Drawing.Size(828, 25);
            this.tblMenu.TabIndex = 1;
            this.tblMenu.Text = "toolStrip1";
            // 
            // tblAddNewStep
            // 
            this.tblAddNewStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tblAddNewStep.Image = global::WorkflowManagement.Properties.Resources.window_new;
            this.tblAddNewStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tblAddNewStep.Name = "tblAddNewStep";
            this.tblAddNewStep.Size = new System.Drawing.Size(23, 22);
            this.tblAddNewStep.Text = "Add New Step";
            // 
            // tblAddNewCon
            // 
            this.tblAddNewCon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tblAddNewCon.Image = global::WorkflowManagement.Properties.Resources.line;
            this.tblAddNewCon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tblAddNewCon.Name = "tblAddNewCon";
            this.tblAddNewCon.Size = new System.Drawing.Size(23, 22);
            this.tblAddNewCon.Text = "Add New Connector";
            this.tblAddNewCon.Click += new System.EventHandler(this.tblAddConnector_Click);
            // 
            // tblDelete
            // 
            this.tblDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tblDelete.Image = global::WorkflowManagement.Properties.Resources.mail_mark_not_junk;
            this.tblDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tblDelete.Name = "tblDelete";
            this.tblDelete.Size = new System.Drawing.Size(23, 22);
            this.tblDelete.Text = "Delete";
            this.tblDelete.Click += new System.EventHandler(this.tblDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(120, 22);
            this.toolStripLabel1.Text = "Next Workflow Name";
            // 
            // cmbNextWorkflow
            // 
            this.cmbNextWorkflow.Name = "cmbNextWorkflow";
            this.cmbNextWorkflow.Size = new System.Drawing.Size(121, 25);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tblMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlContainer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(828, 410);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.BackColor = System.Drawing.Color.Silver;
            this.pnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContainer.Controls.Add(this.pnlCanvas);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(828, 385);
            this.pnlContainer.TabIndex = 2;
            this.pnlContainer.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlContainer_Scroll);
            this.pnlContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContainer_Paint);
            this.pnlContainer.Resize += new System.EventHandler(this.pnlContainer_Resize);
            // 
            // WorkflowDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 410);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WorkflowDesigner";
            this.Text = "Workflow Designer";
            this.Activated += new System.EventHandler(this.WorkflowDesigner_Activated);
            this.Deactivate += new System.EventHandler(this.WorkflowDesigner_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkflowDesigner_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tblMenu.ResumeLayout(false);
            this.tblMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.ToolStrip tblMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.ToolStripButton tblAddNewStep;
        private System.Windows.Forms.ToolStripButton tblAddNewCon;
        private System.Windows.Forms.ToolStripButton tblDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbNextWorkflow;
    }
}

