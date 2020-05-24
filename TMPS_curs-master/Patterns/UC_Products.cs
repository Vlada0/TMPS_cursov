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
    public partial class UC_Products : UserControl
    {
        public event EventHandler BackClick;

        string categoryName;
        int columnsCount = 5;
        int rowsCount = 0;
        private Product selectedProduct;

        ProductContext context;
        int categoryId;

        public UC_Products(string categName)
        {
            InitializeComponent();
            categoryName = categName;

            context = ProductContext.getProductContext();
            categoryId = context.Categories.Where(c => c.Name == categoryName).ToList()[0].CategoryId;

            fillProducts();
        }

        private void fillProducts()
        {
            List<Product> Products = ProductContext.getProductsByCategoryName(categoryName);


            rowsCount = Products.Count / columnsCount;
            if (Products.Count % columnsCount != 0)
                rowsCount += 1;
            if (rowsCount < 5)
                rowsCount = 5;

            tableLayoutPanel_ProductsControl = new TableLayoutPanel();
            //tableLayoutPanel_ProductsControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel_ProductsControl.Dock = DockStyle.Fill;
            tableLayoutPanel_ProductsControl.Location = new Point(0, 0);
            tableLayoutPanel_ProductsControl.Visible = true;

            tableLayoutPanel_ProductsControl.ColumnCount = columnsCount;
            tableLayoutPanel_ProductsControl.RowCount = rowsCount;

            int width = 100 / tableLayoutPanel_ProductsControl.ColumnCount;
            int height = 100 / tableLayoutPanel_ProductsControl.RowCount;

            int k = 0;

            for (int row = 0; row < tableLayoutPanel_ProductsControl.RowCount; row++)
            {
                // add row
                tableLayoutPanel_ProductsControl.RowStyles.Add(new RowStyle(SizeType.Percent, height));

                for (int col = 0; col < tableLayoutPanel_ProductsControl.ColumnCount; col++)
                {
                    // add column
                    tableLayoutPanel_ProductsControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));

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

                        tableLayoutPanel_ProductsControl.Controls.Add(button, col, row);
                        k++;
                    }
                }
            }


            panel1.Controls.Clear();
            panel1.Controls.Add(tableLayoutPanel_ProductsControl);
        }


        private void Product_Click(object sender, EventArgs e)
        {
            selectedProduct = (Product)((Button)sender).Tag;
            button_Edit.Enabled = true;
            button_Delete.Enabled = true;
            button_AddLike.Enabled = true;
            button_Show.Enabled = true;
            //Form_EditProduct formEdit = new Form_EditProduct((Product)((Button)sender).Tag);
            //formEdit.Show();

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Form_AddNew formAdd = new Form_AddNew(categoryId);
            formAdd.Saved += Form_Saved;
            formAdd.Show();
        }

        private void Form_Saved()
        {
            fillProducts();
        }

        private void button_AddLike_Click(object sender, EventArgs e)
        {
            Form_AddLike formAddLike = new Form_AddLike(selectedProduct);
            formAddLike.Saved += Form_Saved;
            formAddLike.Show();
            button_Show.Enabled = false;
            button_Edit.Enabled = false;
            button_Delete.Enabled = false;
            button_AddLike.Enabled = false;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            Form_EditProduct formEdit = new Form_EditProduct(selectedProduct);
            formEdit.Saved += Form_Saved;
            formEdit.Show();
            button_Show.Enabled = false;
            button_Edit.Enabled = false;
            button_Delete.Enabled = false;
            button_AddLike.Enabled = false;
           
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            DialogResult dResult = MessageBox.Show("Are your sure?", "Confirmation", MessageBoxButtons.YesNo);

            if(dResult == DialogResult.Yes)
            {
                //tableLayoutPanel1.Controls.Remove()
                context.Products.Remove(selectedProduct);
                context.SaveChanges();
                fillProducts();

                button_Show.Enabled = false;
                button_Edit.Enabled = false;
                button_Delete.Enabled = false;
                button_AddLike.Enabled = false;
                
            }
            else if (dResult == DialogResult.No)
            {
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            BackClick?.Invoke(sender, e);
        }

        private void button_Show_Click(object sender, EventArgs e)
        {
            Form_InfoProduct info_product = new Form_InfoProduct(selectedProduct);
            info_product.Show();
            button_Show.Enabled = false;
            button_Edit.Enabled = false;
            button_Delete.Enabled = false;
            button_AddLike.Enabled = false;
        }
    }
}
