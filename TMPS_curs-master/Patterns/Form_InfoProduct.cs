using Patterns.Command;
using Patterns.Decorator;
using Patterns.Model;
using Patterns.Prototype;
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
    public partial class Form_InfoProduct : Form
    {
        Product editProduct;
        // Instantiate our undo/redo stack for operations on an integer value
        //UndoRedoStack<Product> ur = new UndoRedoStack<Product>();
        ProductContext context = ProductContext.getProductContext();
        bool manuelChecked = true;

        public Form_InfoProduct(Product productToEdit)
        {
            InitializeComponent();
            editProduct = productToEdit;//.clone();

            createInterface();
            fillInterface();
        }

        private void createInterface()
        {
            if(editProduct is Chair)
            {

            }
        }

        private void fillInterface()
        {
            label_Name.Text = editProduct.Name;
            label_Category.Text = context.Categories
                .Where(cat=>cat.CategoryId == editProduct.CategoryId).ToList()[0].Name;
            richTextBox_description.Text = editProduct.Description;
            label_Price.Text = editProduct.Price.ToString();
            pictureBox_Image.Image = (Image)Properties.Resources.ResourceManager.GetObject(editProduct.Image);
            

            string styleStr = context.Styles.Where(style => style.StyleId == editProduct.StyleId).ToList()[0].Name;
            pictureBox_Style.Image = (Image)Properties.Resources.ResourceManager.GetObject(styleStr);

            string materialStr = context.Materials.Where(mat => mat.MaterialId == editProduct.MaterialId).ToList()[0].Name;
            pictureBox_Material.Image = (Image)Properties.Resources.ResourceManager.GetObject(materialStr);

            string newColorStr = context.Colors.Where(col => col.ColorOptionId == editProduct.ColorId).ToList()[0].Name;
            label_Color.BackColor = Color.FromName(newColorStr);
            

           // if (editProduct is Chair)
            //{
                if(editProduct.Description.IndexOf("with arms") != -1)
                {
                    checkBox_Arms.Checked = true;
                }
                if(editProduct.Description.IndexOf("with headboard") != -1)
                {
                    checkBox_HeadBoard.Checked = true;
                }
           // }
        }

       

        private void button_Collection_Click(object sender, EventArgs e)
        {
            Form_Collection form_collection = new Form_Collection(editProduct.StyleId);
            form_collection.Show();
        }

       
    }
}
