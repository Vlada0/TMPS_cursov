namespace Patterns
{
    partial class Form1
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_Products = new System.Windows.Forms.TabPage();
            this.tabPage_Store = new System.Windows.Forms.TabPage();
            this.tabPage_Clients = new System.Windows.Forms.TabPage();
            this.tabPage_Orders = new System.Windows.Forms.TabPage();
            this.tabPage_Personal = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl_Main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl_Main.Controls.Add(this.tabPage_Products);
            this.tabControl_Main.Controls.Add(this.tabPage_Store);
            this.tabControl_Main.Controls.Add(this.tabPage_Clients);
            this.tabControl_Main.Controls.Add(this.tabPage_Orders);
            this.tabControl_Main.Controls.Add(this.tabPage_Personal);
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.Enabled = false;
            this.tabControl_Main.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl_Main.ItemSize = new System.Drawing.Size(150, 50);
            this.tabControl_Main.Location = new System.Drawing.Point(4, 4);
            this.tabControl_Main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl_Main.Multiline = true;
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1485, 822);
            this.tabControl_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_Main.TabIndex = 0;
            this.tabControl_Main.SelectedIndexChanged += new System.EventHandler(this.tabControl_Main_SelectedIndexChanged);
            // 
            // tabPage_Products
            // 
            this.tabPage_Products.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_Products.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tabPage_Products.Location = new System.Drawing.Point(54, 4);
            this.tabPage_Products.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Products.Name = "tabPage_Products";
            this.tabPage_Products.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Products.Size = new System.Drawing.Size(1427, 814);
            this.tabPage_Products.TabIndex = 0;
            this.tabPage_Products.Text = "Products";
            this.tabPage_Products.UseVisualStyleBackColor = true;
            // 
            // tabPage_Store
            // 
            this.tabPage_Store.Location = new System.Drawing.Point(29, 4);
            this.tabPage_Store.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Store.Name = "tabPage_Store";
            this.tabPage_Store.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Store.Size = new System.Drawing.Size(1452, 814);
            this.tabPage_Store.TabIndex = 1;
            this.tabPage_Store.Text = "Store";
            this.tabPage_Store.UseVisualStyleBackColor = true;
            // 
            // tabPage_Clients
            // 
            this.tabPage_Clients.Location = new System.Drawing.Point(29, 4);
            this.tabPage_Clients.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Clients.Name = "tabPage_Clients";
            this.tabPage_Clients.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Clients.Size = new System.Drawing.Size(1452, 814);
            this.tabPage_Clients.TabIndex = 2;
            this.tabPage_Clients.Text = "Clients";
            this.tabPage_Clients.UseVisualStyleBackColor = true;
            // 
            // tabPage_Orders
            // 
            this.tabPage_Orders.Location = new System.Drawing.Point(29, 4);
            this.tabPage_Orders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Orders.Name = "tabPage_Orders";
            this.tabPage_Orders.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Orders.Size = new System.Drawing.Size(1452, 814);
            this.tabPage_Orders.TabIndex = 3;
            this.tabPage_Orders.Text = "Orders";
            this.tabPage_Orders.UseVisualStyleBackColor = true;
            // 
            // tabPage_Personal
            // 
            this.tabPage_Personal.Location = new System.Drawing.Point(29, 4);
            this.tabPage_Personal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Personal.Name = "tabPage_Personal";
            this.tabPage_Personal.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_Personal.Size = new System.Drawing.Size(1452, 814);
            this.tabPage_Personal.TabIndex = 4;
            this.tabPage_Personal.Text = "Personal";
            this.tabPage_Personal.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl_Main, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1493, 830);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 830);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_Main.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Store;
        private System.Windows.Forms.TabPage tabPage_Clients;
        private System.Windows.Forms.TabPage tabPage_Orders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage_Products;
        private System.Windows.Forms.TabPage tabPage_Personal;
    }
}

