namespace WorkflowApplication
{
    partial class FormWorkflowList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWorkflowList));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.listBoxWorkflows = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddWorkflow = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.listBoxWorkflows);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(342, 448);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(342, 473);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // listBoxWorkflows
            // 
            this.listBoxWorkflows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxWorkflows.FormattingEnabled = true;
            this.listBoxWorkflows.Items.AddRange(new object[] {
            "Printing"});
            this.listBoxWorkflows.Location = new System.Drawing.Point(0, 0);
            this.listBoxWorkflows.Name = "listBoxWorkflows";
            this.listBoxWorkflows.Size = new System.Drawing.Size(342, 448);
            this.listBoxWorkflows.Sorted = true;
            this.listBoxWorkflows.TabIndex = 0;
            this.listBoxWorkflows.DoubleClick += new System.EventHandler(this.listBoxWorkflows_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddWorkflow});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(35, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButtonAddWorkflow
            // 
            this.toolStripButtonAddWorkflow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddWorkflow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddWorkflow.Image")));
            this.toolStripButtonAddWorkflow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddWorkflow.Name = "toolStripButtonAddWorkflow";
            this.toolStripButtonAddWorkflow.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddWorkflow.Text = "Add Workflow";
            this.toolStripButtonAddWorkflow.Click += new System.EventHandler(this.toolStripButtonAddWorkflow_Click);
            // 
            // FormWorkflowList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 473);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "FormWorkflowList";
            this.Text = "List of Workflows";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWorkflowList_FormClosing);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListBox listBoxWorkflows;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddWorkflow;

    }
}