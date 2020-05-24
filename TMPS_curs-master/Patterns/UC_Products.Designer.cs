namespace Patterns
{
    partial class UC_Products
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.tableLayoutPanel_ProductsControl = new System.Windows.Forms.TableLayoutPanel();
            this.button_Back = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_AddLike = new System.Windows.Forms.Button();
            this.button_Show = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Delete
            // 
            this.button_Delete.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Delete.Enabled = false;
            this.button_Delete.FlatAppearance.BorderSize = 0;
            this.button_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Delete.Location = new System.Drawing.Point(1007, 570);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(99, 50);
            this.button_Delete.TabIndex = 8;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = false;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Edit.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Edit.Enabled = false;
            this.button_Edit.FlatAppearance.BorderSize = 0;
            this.button_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit.Location = new System.Drawing.Point(579, 570);
            this.button_Edit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(99, 50);
            this.button_Edit.TabIndex = 7;
            this.button_Edit.Text = "Edit";
            this.button_Edit.UseVisualStyleBackColor = false;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Add
            // 
            this.button_Add.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Add.FlatAppearance.BorderSize = 0;
            this.button_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Add.Location = new System.Drawing.Point(793, 570);
            this.button_Add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(99, 50);
            this.button_Add.TabIndex = 6;
            this.button_Add.Text = "Add new";
            this.button_Add.UseVisualStyleBackColor = false;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // tableLayoutPanel_ProductsControl
            // 
            this.tableLayoutPanel_ProductsControl.BackColor = System.Drawing.Color.PapayaWhip;
            this.tableLayoutPanel_ProductsControl.ColumnCount = 2;
            this.tableLayoutPanel_ProductsControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_ProductsControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_ProductsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_ProductsControl.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_ProductsControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel_ProductsControl.Name = "tableLayoutPanel_ProductsControl";
            this.tableLayoutPanel_ProductsControl.RowCount = 2;
            this.tableLayoutPanel_ProductsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_ProductsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_ProductsControl.Size = new System.Drawing.Size(1081, 580);
            this.tableLayoutPanel_ProductsControl.TabIndex = 5;
            // 
            // button_Back
            // 
            this.button_Back.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Back.FlatAppearance.BorderSize = 0;
            this.button_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Back.Location = new System.Drawing.Point(4, 570);
            this.button_Back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(99, 50);
            this.button_Back.TabIndex = 9;
            this.button_Back.Text = "<<";
            this.button_Back.UseVisualStyleBackColor = false;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(0, 580);
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.tableLayoutPanel_ProductsControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 558);
            this.panel1.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Back, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Delete, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Edit, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_AddLike, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Add, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Show, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1110, 636);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // button_AddLike
            // 
            this.button_AddLike.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AddLike.BackColor = System.Drawing.Color.SkyBlue;
            this.button_AddLike.Enabled = false;
            this.button_AddLike.FlatAppearance.BorderSize = 0;
            this.button_AddLike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddLike.Location = new System.Drawing.Point(900, 570);
            this.button_AddLike.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_AddLike.Name = "button_AddLike";
            this.button_AddLike.Size = new System.Drawing.Size(99, 50);
            this.button_AddLike.TabIndex = 11;
            this.button_AddLike.Text = "Add like...";
            this.button_AddLike.UseVisualStyleBackColor = false;
            this.button_AddLike.Click += new System.EventHandler(this.button_AddLike_Click);
            // 
            // button_Show
            // 
            this.button_Show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Show.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Show.Enabled = false;
            this.button_Show.FlatAppearance.BorderSize = 0;
            this.button_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Show.Location = new System.Drawing.Point(686, 570);
            this.button_Show.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Show.Name = "button_Show";
            this.button_Show.Size = new System.Drawing.Size(99, 50);
            this.button_Show.TabIndex = 12;
            this.button_Show.Text = "Show info";
            this.button_Show.UseVisualStyleBackColor = false;
            this.button_Show.Click += new System.EventHandler(this.button_Show_Click);
            // 
            // UC_Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UC_Products";
            this.Size = new System.Drawing.Size(1110, 636);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ProductsControl;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_AddLike;
        private System.Windows.Forms.Button button_Show;
    }
}
