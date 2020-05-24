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
    public partial class Form_EditProduct : Form
    {
        public delegate void SavedHandler();
        public event SavedHandler Saved;

        Product editProduct;
        // Instantiate our undo/redo stack for operations on an integer value
        UndoRedoStack<Product> ur = new UndoRedoStack<Product>();
        ProductContext context = ProductContext.getProductContext();
        bool manuelChecked = true;

        public Form_EditProduct(Product productToEdit)
        {
            InitializeComponent();
            editProduct = productToEdit;//.clone();

            createInterface();
            fillInterface();

            ur.UndoRedoCountChanged += Ur_UndoRedoCountChanged;
        }

        private void Ur_UndoRedoCountChanged(string action, bool enable)
        {
            if (action == "undo")
                button_Undo.Enabled = enable;
            if (action == "redo")
                button_Redo.Enabled = enable;
        }

        private void createInterface()
        {
            if(editProduct is Chair)
            {

            }
        }

        private void fillInterface()
        {
            comboBox_category.Items.AddRange(context.Categories.ToArray());
            comboBox_category.DisplayMember = "Name";

            textBox_name.Text = editProduct.Name;
            comboBox_category.SelectedItem = context.Categories
                .Where(cat=>cat.CategoryId == editProduct.CategoryId).ToList()[0];
            richTextBox_description.Text = editProduct.Description;
            textBox_price.Text = editProduct.Price.ToString();
            pictureBox_Image.Image = (Image)Properties.Resources.ResourceManager.GetObject(editProduct.Image);

            //ProductContext dbContext = ProductContext.getProductContext();

            string styleStr = context.Styles.Where(style => style.StyleId == editProduct.StyleId).ToList()[0].Name;
            pictureBox_Style.Image = (Image)Properties.Resources.ResourceManager.GetObject(styleStr);

            string materialStr = context.Materials.Where(mat => mat.MaterialId == editProduct.MaterialId).ToList()[0].Name;
            pictureBox_Material.Image = (Image)Properties.Resources.ResourceManager.GetObject(materialStr);

            string newColorStr = context.Colors.Where(col => col.ColorOptionId == editProduct.ColorId).ToList()[0].Name;
            label_Color.BackColor = Color.FromName(newColorStr);
            

         //   if (editProduct is Chair)
          //  {
                
                if (editProduct.Description.IndexOf("with arms") != -1)
                {
                    checkBox_Arms.Checked = true;
                }
                if (editProduct.Description.IndexOf("with headboards") != -1)
                {
                    checkBox_HeadBoard.Checked = true;
                }
                
            //}
        }

       

        private void button_Undo_Click(object sender, EventArgs e)
        {
            editProduct = ur.Undo((Product)editProduct);
            //if (ur.UndoCount == 0)
            //    button_Undo.Enabled = false;
        }

        private void button_Redo_Click(object sender, EventArgs e)
        {
            editProduct = ur.Redo((Product)editProduct);
            //if (ur.RedoCount == 0)
            //    button_Redo.Enabled = false;
        }

        private void Form_EditProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Ctrl +z
        }

      

        private void label_Color_Click(object sender, EventArgs e)
        {
            //ProductContext dbContext = ProductContext.getProductContext();
            string colorStr = ((Label)sender).Tag.ToString();

            Color newColor = Color.FromName(colorStr);

            int newColorId = context.Colors.Where(color=> color.Name == colorStr).ToList()[0].ColorOptionId;
            int prevColorId = editProduct.ColorId;

            ChangeColorCommand commandChangeColor = new ChangeColorCommand(newColorId, prevColorId);
            commandChangeColor.UndoEvent += CommandChangeColor_UndoDoEvent;
            commandChangeColor.DoEvent += CommandChangeColor_UndoDoEvent;
            editProduct = ur.Do(commandChangeColor, editProduct);
        }

        private void CommandChangeColor_UndoDoEvent(int value)
        {
            //ProductContext dbContext = ProductContext.getProductContext();
            string colorStr = context.Colors.Where(col => col.ColorOptionId == value).ToList()[0].Name;
            label_Color.BackColor = Color.FromName(colorStr);
        }

        private void pictureBox_Style_Click(object sender, EventArgs e)
        {
            //ProductContext dbContext = ProductContext.getProductContext();
            string styleStr = ((PictureBox)sender).Tag.ToString();
            
            int newStyleId = context.Styles.Where(st => st.Name == styleStr).ToList()[0].StyleId;
            int prevStyleId = editProduct.StyleId;

            ChangeStyleCommand commandStyleChange = new ChangeStyleCommand(newStyleId, prevStyleId);
            commandStyleChange.UndoEvent += CommandStyleChange_UndoDoEvent;
            commandStyleChange.DoEvent += CommandStyleChange_UndoDoEvent;
            editProduct = ur.Do(commandStyleChange, editProduct);

            //pictureBox_Image.Image = (Image)Properties.Resources.ResourceManager.GetObject(editProduct.Image);
            //pictureBox_Style.Image = (Image)Properties.Resources.ResourceManager.GetObject(styleStr);
        }

        private void CommandStyleChange_UndoDoEvent(int value)
        {
            //ProductContext dbContext = ProductContext.getProductContext();
            string styleStr = context.Styles.Where(st => st.StyleId == value).ToList()[0].Name;
            pictureBox_Style.Image = (Image)Properties.Resources.ResourceManager.GetObject(styleStr);
        }
        
        private void pictureBox_Material_Click(object sender, EventArgs e)
        {
            //ProductContext dbContext = ProductContext.getProductContext();
            string materialStr = ((PictureBox)sender).Tag.ToString();

            int newMaterialId = context.Materials.Where(mat => mat.Name == materialStr).ToList()[0].MaterialId;
            int prevMaterialId = editProduct.MaterialId;

            ChangeMaterialCommand commandMaterialChange = new ChangeMaterialCommand(newMaterialId, prevMaterialId);
            commandMaterialChange.UndoEvent += CommandMaterialChange_UndoDoEvent;
            commandMaterialChange.DoEvent += CommandMaterialChange_UndoDoEvent;
            editProduct = ur.Do(commandMaterialChange, editProduct);

            //pictureBox_Material.Image = (Image)Properties.Resources.ResourceManager.GetObject(materialStr);
        }

        private void CommandMaterialChange_UndoDoEvent(int value)
        {
            //ProductContext dbContext = ProductContext.getProductContext();
            string materialStr = context.Materials.Where(mat => mat.MaterialId == value).ToList()[0].Name;
            pictureBox_Material.Image = (Image)Properties.Resources.ResourceManager.GetObject(materialStr);
        }


        private void checkBox_Arms_CheckedChanged(object sender, EventArgs e)
        {
            AddArmsCommand commandAddArms = new AddArmsCommand(checkBox_Arms.Checked);
            commandAddArms.UndoEvent += CommandAddArms_UndoDoEvent;
            commandAddArms.DoEvent += CommandAddArms_UndoDoEvent;
            //if (checkBox_Arms.Checked)
            //{
            //    editProduct = new ArmsDecorator(editProduct);
            //}
            //else editProduct = ((ArmsDecorator)editProduct).Wrappee;

            //else editProduct = cmd.Undo(input);
            //editProduct = new ArmsDecorator(editProduct);
            if(manuelChecked)
                editProduct = ur.Do(commandAddArms, editProduct);
            
            //label_Description.Text = editProduct.Description;
        }

        private void CommandAddArms_UndoDoEvent(bool value)
        {
            if (value && !checkBox_Arms.Checked  || !value && checkBox_Arms.Checked)
            {
                manuelChecked = false;
                checkBox_Arms.Checked = value;
                manuelChecked = true;
            }

            richTextBox_description.Text = editProduct.Description;
        }

        private void checkBox_HeadBoard_CheckedChanged(object sender, EventArgs e)
        {
            AddHeadboardCommand commandAddHeadboard = new AddHeadboardCommand(checkBox_HeadBoard.Checked);
            commandAddHeadboard.UndoEvent += CommandAddHeadboard_UndoDoEvent;
            commandAddHeadboard.DoEvent += CommandAddHeadboard_UndoDoEvent;

            //editProduct = new HeadBoardDecorator(editProduct);
            if(manuelChecked)
                editProduct = ur.Do(commandAddHeadboard, editProduct);

            //label_Description.Text = editProduct.Description;
        }

        private void CommandAddHeadboard_UndoDoEvent(bool value)
        {
            if (value && !checkBox_HeadBoard.Checked || !value && checkBox_HeadBoard.Checked)
            {
                manuelChecked = false;
                checkBox_HeadBoard.Checked = value;
                manuelChecked = true;
            }

            richTextBox_description.Text = editProduct.Description;
        }
        

        private void button_Save_Click(object sender, EventArgs e)
        {
            //  ProductContext context = ProductContext.getProductContext();
            //?? сохраемит editProduct в List/table
            editProduct.Name = textBox_name.Text;
            editProduct.CategoryId = ((Category)(comboBox_category.SelectedItem)).CategoryId;
            editProduct.Category = (Category)(comboBox_category.SelectedItem);
            editProduct.Price = Convert.ToDouble(textBox_price.Text);
            editProduct.Description = richTextBox_description.Text;

            context.SaveChanges();

            this.Close();
        }

        private void button_SaveNew_Click(object sender, EventArgs e)
        {
            
            //Prototype
            Product newProduct = editProduct.clone();
            //editProduct = 

            context.Products.Add(newProduct);
            context.SaveChanges();
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
                    int startIndex= dlg.FileName.LastIndexOf('\\')+1;
                    int length = dlg.FileName.LastIndexOf('.') - startIndex;
                    String fileName = dlg.FileName.Substring(startIndex, length);
                    pictureBox_Image.Image = new Bitmap(dlg.FileName);
                    pictureBox_Image.Tag = fileName;
                    editProduct.Image = fileName;
                    //Properties.Resources.ResourceManager.A
                    context.SaveChanges();

                }
            }
        }

        private void Form_EditProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            Saved?.Invoke();
        }
    }
}
