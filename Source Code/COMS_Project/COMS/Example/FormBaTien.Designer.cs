namespace Example
{
    partial class FormBaTien
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
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnCreateDept = new System.Windows.Forms.Button();
            this.btnCreateEmpl = new System.Windows.Forms.Button();
            this.btnCreateRole = new System.Windows.Forms.Button();
            this.txtBxUsername = new System.Windows.Forms.TextBox();
            this.txtBxPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCreateCustomer = new System.Windows.Forms.Button();
            this.btnCreateWorkflow = new System.Windows.Forms.Button();
            this.btnCreateCylinder = new System.Windows.Forms.Button();
            this.btnViewQueue = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(12, 12);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(75, 23);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Clicked);
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Location = new System.Drawing.Point(93, 12);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(80, 23);
            this.btnUpdateOrder.TabIndex = 1;
            this.btnUpdateOrder.Text = "Update Order";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Clicked);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(179, 12);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(83, 23);
            this.btnDeleteOrder.TabIndex = 2;
            this.btnDeleteOrder.Text = "Delete Orders";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Clicked);
            // 
            // btnCreateDept
            // 
            this.btnCreateDept.Location = new System.Drawing.Point(12, 54);
            this.btnCreateDept.Name = "btnCreateDept";
            this.btnCreateDept.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDept.TabIndex = 4;
            this.btnCreateDept.Text = "Create Dept";
            this.btnCreateDept.UseVisualStyleBackColor = true;
            this.btnCreateDept.Click += new System.EventHandler(this.btnCreateDept_Clicked);
            // 
            // btnCreateEmpl
            // 
            this.btnCreateEmpl.Location = new System.Drawing.Point(94, 54);
            this.btnCreateEmpl.Name = "btnCreateEmpl";
            this.btnCreateEmpl.Size = new System.Drawing.Size(95, 23);
            this.btnCreateEmpl.TabIndex = 5;
            this.btnCreateEmpl.Text = "Create Employee";
            this.btnCreateEmpl.UseVisualStyleBackColor = true;
            this.btnCreateEmpl.Click += new System.EventHandler(this.btnCreateEmpl_Clicked);
            // 
            // btnCreateRole
            // 
            this.btnCreateRole.Location = new System.Drawing.Point(195, 54);
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Size = new System.Drawing.Size(75, 23);
            this.btnCreateRole.TabIndex = 6;
            this.btnCreateRole.Text = "Create Role";
            this.btnCreateRole.UseVisualStyleBackColor = true;
            this.btnCreateRole.Click += new System.EventHandler(this.btnCreateRole_Clicked);
            // 
            // txtBxUsername
            // 
            this.txtBxUsername.Location = new System.Drawing.Point(12, 95);
            this.txtBxUsername.Name = "txtBxUsername";
            this.txtBxUsername.Size = new System.Drawing.Size(100, 20);
            this.txtBxUsername.TabIndex = 7;
            this.txtBxUsername.Text = "username";
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.Location = new System.Drawing.Point(119, 95);
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.PasswordChar = '*';
            this.txtBxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtBxPassword.TabIndex = 8;
            this.txtBxPassword.Text = "password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(225, 93);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Clicked);
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.Location = new System.Drawing.Point(12, 132);
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.Size = new System.Drawing.Size(100, 23);
            this.btnCreateCustomer.TabIndex = 10;
            this.btnCreateCustomer.Text = "Create Customer";
            this.btnCreateCustomer.UseVisualStyleBackColor = true;
            this.btnCreateCustomer.Click += new System.EventHandler(this.btnCreateCustomer_Clicked);
            // 
            // btnCreateWorkflow
            // 
            this.btnCreateWorkflow.Location = new System.Drawing.Point(119, 132);
            this.btnCreateWorkflow.Name = "btnCreateWorkflow";
            this.btnCreateWorkflow.Size = new System.Drawing.Size(100, 23);
            this.btnCreateWorkflow.TabIndex = 11;
            this.btnCreateWorkflow.Text = "Create Workflow";
            this.btnCreateWorkflow.UseVisualStyleBackColor = true;
            this.btnCreateWorkflow.Click += new System.EventHandler(this.btnCreateWorkflow_Clicked);
            // 
            // btnCreateCylinder
            // 
            this.btnCreateCylinder.Location = new System.Drawing.Point(225, 132);
            this.btnCreateCylinder.Name = "btnCreateCylinder";
            this.btnCreateCylinder.Size = new System.Drawing.Size(86, 23);
            this.btnCreateCylinder.TabIndex = 12;
            this.btnCreateCylinder.Text = "Create Cylinder";
            this.btnCreateCylinder.UseVisualStyleBackColor = true;
            this.btnCreateCylinder.Click += new System.EventHandler(this.btnCreateCylinder_Clicked);
            // 
            // btnViewQueue
            // 
            this.btnViewQueue.Location = new System.Drawing.Point(13, 171);
            this.btnViewQueue.Name = "btnViewQueue";
            this.btnViewQueue.Size = new System.Drawing.Size(75, 23);
            this.btnViewQueue.TabIndex = 13;
            this.btnViewQueue.Text = "View Queue";
            this.btnViewQueue.UseVisualStyleBackColor = true;
            this.btnViewQueue.Click += new System.EventHandler(this.btnViewQueue_Clicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Next Order ID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormBaTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnViewQueue);
            this.Controls.Add(this.btnCreateCylinder);
            this.Controls.Add(this.btnCreateWorkflow);
            this.Controls.Add(this.btnCreateCustomer);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtBxPassword);
            this.Controls.Add(this.txtBxUsername);
            this.Controls.Add(this.btnCreateRole);
            this.Controls.Add(this.btnCreateEmpl);
            this.Controls.Add(this.btnCreateDept);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnUpdateOrder);
            this.Controls.Add(this.btnCreateOrder);
            this.Name = "FormBaTien";
            this.Text = "TestForm BaTien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnCreateDept;
        private System.Windows.Forms.Button btnCreateEmpl;
        private System.Windows.Forms.Button btnCreateRole;
        private System.Windows.Forms.TextBox txtBxUsername;
        private System.Windows.Forms.TextBox txtBxPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCreateCustomer;
        private System.Windows.Forms.Button btnCreateWorkflow;
        private System.Windows.Forms.Button btnCreateCylinder;
        private System.Windows.Forms.Button btnViewQueue;
        private System.Windows.Forms.Button button1;
    }
}