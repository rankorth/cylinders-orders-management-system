namespace WorkflowApplication
{
    partial class FormStepList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStepList));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.listBoxSteps = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddStep = new System.Windows.Forms.ToolStripButton();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.listBoxSteps);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(342, 411);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(342, 449);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // listBoxSteps
            // 
            this.listBoxSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSteps.FormattingEnabled = true;
            this.listBoxSteps.Items.AddRange(new object[] {
            "Printing Cylinder"});
            this.listBoxSteps.Location = new System.Drawing.Point(0, 0);
            this.listBoxSteps.Name = "listBoxSteps";
            this.listBoxSteps.Size = new System.Drawing.Size(342, 411);
            this.listBoxSteps.Sorted = true;
            this.listBoxSteps.TabIndex = 0;
            this.listBoxSteps.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.listBoxSteps_QueryContinueDrag);
            this.listBoxSteps.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxSteps_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddStep});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(71, 38);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButtonAddStep
            // 
            this.toolStripButtonAddStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddStep.Image")));
            this.toolStripButtonAddStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddStep.Name = "toolStripButtonAddStep";
            this.toolStripButtonAddStep.Size = new System.Drawing.Size(59, 35);
            this.toolStripButtonAddStep.Text = "Add Step";
            this.toolStripButtonAddStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAddStep.Click += new System.EventHandler(this.toolStripButtonAddStep_Click);
            // 
            // FormStepList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 449);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "FormStepList";
            this.Text = "List of Steps";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStepList_FormClosing);
            this.Load += new System.EventHandler(this.FormStepList_Load);
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
        private System.Windows.Forms.ToolStripButton toolStripButtonAddStep;
        private System.Windows.Forms.ListBox listBoxSteps;

    }
}