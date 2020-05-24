using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patterns.Model;

namespace Patterns
{
    public partial class UC_Categories : UserControl
    {
        public event EventHandler CategoryClick;

        int columnsCount = 5;
        int rowsCount = 0;


        public UC_Categories()
        {
            InitializeComponent();

            fillCategories();
        }

        private void fillCategories()
        {
            List<Category> Categories = ProductContext.getProductContext().Categories.ToList();
            
        
            rowsCount = Categories.Count / columnsCount;
            if (Categories.Count % columnsCount != 0)
                rowsCount += 1;
            if (rowsCount < 5)
                rowsCount = 5;

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Visible = true;

            tableLayoutPanel1.ColumnCount = columnsCount;
            tableLayoutPanel1.RowCount = rowsCount;

            int width = 100 / tableLayoutPanel1.ColumnCount;
            int height = 100 / tableLayoutPanel1.RowCount;

            int k = 0;

            for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
            {
                // add row
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, height));

                for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                {
                    // add column
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));

                    if (k < Categories.Count)
                    {

                        Category category = Categories[k];
                        Button button = new Button();
                        button.Text = category.Name;
                        button.Tag = category.CategoryId;
                        button.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(category.Image);
                        button.BackgroundImageLayout = ImageLayout.Stretch;
                        button.TextAlign = ContentAlignment.BottomCenter;
                        button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                        button.Margin = new Padding(10,10,10,10);
                        

                        button.Click += Category_Click;

                        tableLayoutPanel1.Controls.Add(button, col, row);
                        k++;
                    }
                }
            }


            Controls.Clear();
            Controls.Add(tableLayoutPanel1);

        }

        private void Category_Click(object sender, EventArgs e)
        {
            CategoryClick?.Invoke(sender, e);
        }
    }
}
