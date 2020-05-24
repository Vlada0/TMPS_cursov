namespace Patterns
{
    partial class UC_Personal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Departments = new System.Windows.Forms.TabPage();
            this.tabPage_Employees = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Departments);
            this.tabControl1.Controls.Add(this.tabPage_Employees);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1237, 693);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_Departments
            // 
            this.tabPage_Departments.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Departments.Name = "tabPage_Departments";
            this.tabPage_Departments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Departments.Size = new System.Drawing.Size(1229, 664);
            this.tabPage_Departments.TabIndex = 0;
            this.tabPage_Departments.Text = "Отделы";
            this.tabPage_Departments.UseVisualStyleBackColor = true;
            // 
            // tabPage_Employees
            // 
            this.tabPage_Employees.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Employees.Name = "tabPage_Employees";
            this.tabPage_Employees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Employees.Size = new System.Drawing.Size(1229, 664);
            this.tabPage_Employees.TabIndex = 1;
            this.tabPage_Employees.Text = "Сотрудники";
            this.tabPage_Employees.UseVisualStyleBackColor = true;
            // 
            // UC_Personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UC_Personal";
            this.Size = new System.Drawing.Size(1237, 693);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Departments;
        private System.Windows.Forms.TabPage tabPage_Employees;
    }
}
