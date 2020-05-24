namespace Patterns
{
    partial class UC_Orders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_Orders = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_delete_order = new System.Windows.Forms.Button();
            this.button_save_changes = new System.Windows.Forms.Button();
            this.button_Process = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orders)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_Orders, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.09894F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1467, 775);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridView_Orders
            // 
            this.dataGridView_Orders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Orders.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridView_Orders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Orders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Orders.ColumnHeadersHeight = 25;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Orders.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Orders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Orders.EnableHeadersVisualStyles = false;
            this.dataGridView_Orders.Location = new System.Drawing.Point(4, 4);
            this.dataGridView_Orders.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Orders.Name = "dataGridView_Orders";
            this.dataGridView_Orders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Orders.Size = new System.Drawing.Size(1459, 667);
            this.dataGridView_Orders.TabIndex = 0;
            this.dataGridView_Orders.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_Orders_CellBeginEdit);
            this.dataGridView_Orders.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Orders_CellEndEdit);
            this.dataGridView_Orders.SelectionChanged += new System.EventHandler(this.dataGridView_Orders_SelectionChanged);
            this.dataGridView_Orders.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_Orders_UserAddedRow);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.button_delete_order, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_save_changes, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Process, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 679);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1459, 92);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // button_delete_order
            // 
            this.button_delete_order.BackColor = System.Drawing.Color.SkyBlue;
            this.button_delete_order.Enabled = false;
            this.button_delete_order.FlatAppearance.BorderSize = 0;
            this.button_delete_order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete_order.Location = new System.Drawing.Point(1329, 15);
            this.button_delete_order.Margin = new System.Windows.Forms.Padding(10, 15, 10, 4);
            this.button_delete_order.Name = "button_delete_order";
            this.button_delete_order.Size = new System.Drawing.Size(100, 64);
            this.button_delete_order.TabIndex = 2;
            this.button_delete_order.Text = "Delete rows";
            this.button_delete_order.UseVisualStyleBackColor = false;
            this.button_delete_order.Click += new System.EventHandler(this.button_delete_order_Click);
            // 
            // button_save_changes
            // 
            this.button_save_changes.BackColor = System.Drawing.Color.SkyBlue;
            this.button_save_changes.Enabled = false;
            this.button_save_changes.FlatAppearance.BorderSize = 0;
            this.button_save_changes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save_changes.Location = new System.Drawing.Point(1209, 15);
            this.button_save_changes.Margin = new System.Windows.Forms.Padding(10, 15, 10, 4);
            this.button_save_changes.Name = "button_save_changes";
            this.button_save_changes.Size = new System.Drawing.Size(100, 64);
            this.button_save_changes.TabIndex = 3;
            this.button_save_changes.Text = "Save Changes";
            this.button_save_changes.UseVisualStyleBackColor = false;
            this.button_save_changes.Click += new System.EventHandler(this.button_save_changes_Click);
            // 
            // button_Process
            // 
            this.button_Process.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Process.Enabled = false;
            this.button_Process.FlatAppearance.BorderSize = 0;
            this.button_Process.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Process.Location = new System.Drawing.Point(1089, 15);
            this.button_Process.Margin = new System.Windows.Forms.Padding(10, 15, 10, 4);
            this.button_Process.Name = "button_Process";
            this.button_Process.Size = new System.Drawing.Size(100, 64);
            this.button_Process.TabIndex = 0;
            this.button_Process.Text = "Process order";
            this.button_Process.UseVisualStyleBackColor = false;
            this.button_Process.Click += new System.EventHandler(this.button_ProcessOrder_Click);
            // 
            // UC_Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Orders";
            this.Size = new System.Drawing.Size(1467, 775);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orders)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView_Orders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_Process;
        private System.Windows.Forms.Button button_delete_order;
        private System.Windows.Forms.Button button_save_changes;
    }
}
