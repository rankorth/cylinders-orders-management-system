namespace WorkflowManagement
{
    partial class OpenDialog
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
            this.dgWorkflows = new System.Windows.Forms.DataGridView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextWorkflowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkflows)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWorkflows
            // 
            this.dgWorkflows.AllowUserToAddRows = false;
            this.dgWorkflows.AllowUserToDeleteRows = false;
            this.dgWorkflows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWorkflows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.NextWorkflowName,
            this.ID});
            this.dgWorkflows.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgWorkflows.Location = new System.Drawing.Point(0, 0);
            this.dgWorkflows.MultiSelect = false;
            this.dgWorkflows.Name = "dgWorkflows";
            this.dgWorkflows.ReadOnly = true;
            this.dgWorkflows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWorkflows.Size = new System.Drawing.Size(460, 209);
            this.dgWorkflows.TabIndex = 0;
            this.dgWorkflows.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWorkflows_CellContentClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(301, 213);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(382, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // NextWorkflowName
            // 
            this.NextWorkflowName.DataPropertyName = "NextWorkflowName";
            this.NextWorkflowName.HeaderText = "Next Workflow Name";
            this.NextWorkflowName.Name = "NextWorkflowName";
            this.NextWorkflowName.ReadOnly = true;
            this.NextWorkflowName.Width = 200;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "GUID";
            this.ID.HeaderText = "GUID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // OpenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 240);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.dgWorkflows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OpenDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Workflow";
            this.Load += new System.EventHandler(this.OpenDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkflows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgWorkflows;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextWorkflowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;

    }
}