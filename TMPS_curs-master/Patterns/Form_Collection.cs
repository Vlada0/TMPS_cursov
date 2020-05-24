using Patterns.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patterns
{
    public partial class Form_Collection : Form
    {
        int columnsCount = 5;
        int rowsCount = 0;
        ProductContext context;

        public Form_Collection(int styleID)
        {
            InitializeComponent();
            context = ProductContext.getProductContext();
            fillProducts(styleID);
            
        }
        private void fillProducts(int styleID)
        {
            List<Product> Products = context.Products.ToList().Where(pr => pr.StyleId == styleID).ToList();

            rowsCount = Products.Count / columnsCount;
            if (Products.Count % columnsCount != 0)
                rowsCount += 1;
            if (rowsCount < 5)
                rowsCount = 5;

            tableLayoutPanel1 = new TableLayoutPanel();
            //tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel1.BackColor = Color.PapayaWhip;
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

                    if (k < Products.Count)
                    {


                        Product product = Products[k];
                        Button button = new Button();
                        button.Text = product.Name;
                        button.Tag = product;
                        button.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(product.Image);
                        button.BackgroundImageLayout = ImageLayout.Stretch;
                        button.TextAlign = ContentAlignment.BottomCenter;
                        button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                        button.Margin = new Padding(10, 10, 10, 10);


                        button.Click += Product_Click;

                        tableLayoutPanel1.Controls.Add(button, col, row);
                        k++;
                    }
                }
            }
            Controls.Clear();
            Controls.Add(tableLayoutPanel1);
        }

        private void Product_Click(object sender, EventArgs e)
        {
            Form_InfoProduct info = new Form_InfoProduct((Product)(((Button)sender).Tag));
            info.Show();
        }
    }
}
