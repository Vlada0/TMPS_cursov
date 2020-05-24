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
    public partial class Form_AddNew : Form
    {
        public delegate void SavedHandler();
        public event SavedHandler Saved;

        ProductContext context;
        Product newProduct;


        public Form_AddNew(int categoryId)
        {
            InitializeComponent();

            context = ProductContext.getProductContext();
            newProduct = new Product();

            createInterface(categoryId);
            fillInterface(categoryId);
        }

        private void createInterface(int categoryId)
        {
            if(categoryId == 1) // Tables
            {

            }
            else if (categoryId == 2) // Tables
            {

            }
            else if (categoryId == 3) // Tables
            {

            }
        }

        public void fillInterface(int categoryId)
        {
            comboBox_Category.Items.AddRange(context.Categories.ToArray());
            comboBox_Category.DisplayMember = "Name";
            comboBox_Category.SelectedItem = context.Categories.Where(c => c.CategoryId == categoryId).ToList()[0];
        }


        private void comboBox_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            newProduct.CategoryId = context.Categories.ToList()
                .Where(c=>c.Name == ((Category)comboBox_Category.SelectedItem).Name.ToString())
                .ToList()[0].CategoryId;
        }

        private void button_SelectPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Multiselect = false;
                dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";
                dlg.InitialDirectory = Application.StartupPath + "\\Resources\\";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    int startIndex = dlg.FileName.LastIndexOf('\\') + 1;
                    int length = dlg.FileName.LastIndexOf('.') - startIndex;
                    String fileName = dlg.FileName.Substring(startIndex, length);
                    pictureBox_Picture.Image = new Bitmap(dlg.FileName);
                    pictureBox_Picture.Tag = fileName;
                    newProduct.Image = fileName;
                    //Properties.Resources.ResourceManager.A
                    context.SaveChanges();

                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            newProduct.Name = textBox_Name.Text;
            newProduct.CategoryId = ((Category)(comboBox_Category.SelectedItem)).CategoryId;
            newProduct.Category = (Category)(comboBox_Category.SelectedItem);
            newProduct.Price = Convert.ToDouble(textBox_Price.Text);
            newProduct.Description = richTextBox_Description.Text;

            context.Products.Add(newProduct);
            context.SaveChanges();
            

            this.Close();
        }

        private void pictureBox_Style_Click(object sender, EventArgs e)
        {
            string styleStr = ((PictureBox)sender).Tag.ToString();

            int newStyleId = context.Styles.Where(st => st.Name == styleStr).ToList()[0].StyleId;
            newProduct.StyleId = newStyleId;

            pictureBox_Style.Image = (Image)Properties.Resources.ResourceManager.GetObject(styleStr);

            
            //ChangeStyleCommand commandStyleChange = new ChangeStyleCommand(newStyleId, prevStyleId);
            //commandStyleChange.UndoEvent += CommandStyleChange_UndoDoEvent;
            //commandStyleChange.DoEvent += CommandStyleChange_UndoDoEvent;
            //editProduct = ur.Do(commandStyleChange, editProduct);
        }

        private void pictureBox_Material_Click(object sender, EventArgs e)
        {
            string materialStr = ((PictureBox)sender).Tag.ToString();

            int newMaterialId = context.Materials.Where(mat => mat.Name == materialStr).ToList()[0].MaterialId;
            newProduct.MaterialId = newMaterialId;
            //int prevMaterialId = newProduct.MaterialId;
            pictureBox_Material.Image = (Image)Properties.Resources.ResourceManager.GetObject(materialStr);

            //ChangeMaterialCommand commandMaterialChange = new ChangeMaterialCommand(newMaterialId, prevMaterialId);
            //commandMaterialChange.UndoEvent += CommandMaterialChange_UndoDoEvent;
            //commandMaterialChange.DoEvent += CommandMaterialChange_UndoDoEvent;
            //editProduct = ur.Do(commandMaterialChange, editProduct);
        }

        private void label_Color_Click(object sender, EventArgs e)
        {
            string colorStr = ((Label)sender).Tag.ToString();

            Color newColor = Color.FromName(colorStr);

            int newColorId = context.Colors.Where(color => color.Name == colorStr).ToList()[0].ColorOptionId;
            newProduct.ColorId = newColorId;

            label_Color.BackColor = ((Label)sender).BackColor;
            //int prevColorId = editProduct.ColorId;

            //ChangeColorCommand commandChangeColor = new ChangeColorCommand(newColorId, prevColorId);
            //commandChangeColor.UndoEvent += CommandChangeColor_UndoDoEvent;
            //commandChangeColor.DoEvent += CommandChangeColor_UndoDoEvent;
            //editProduct = ur.Do(commandChangeColor, editProduct);
        }

        private void Form_AddNew_FormClosed(object sender, FormClosedEventArgs e)
        {
            Saved?.Invoke();
        }

        private void checkBox_Arms_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Arms.Checked)
            {
                newProduct.Description += " with arms";
                newProduct.Price += 100;
               
            }

            else
            {
                newProduct.Description = newProduct.Description.Replace(" with arms", "");
                newProduct.Price -= 100;
            }
            richTextBox_Description.Text = newProduct.Description;
            textBox_Price.Text = newProduct.Price.ToString();
        }

        private void checkBox_HeadBoard_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_HeadBoard.Checked)
            {
                newProduct.Description += " with headboard";
                newProduct.Price += 200;
            }
            else
            {
                newProduct.Description = newProduct.Description.Replace(" with headboard", "");
                newProduct.Price -= 200;
            }
            richTextBox_Description.Text = newProduct.Description;
            textBox_Price.Text = newProduct.Price.ToString();
        }

        private void richTextBox_Description_TextChanged(object sender, EventArgs e)
        {
            newProduct.Description = richTextBox_Description.Text;
        }

        private void textBox_Price_TextChanged(object sender, EventArgs e)
        {
            newProduct.Price = Convert.ToDouble(textBox_Price.Text);
        }
    }
}
