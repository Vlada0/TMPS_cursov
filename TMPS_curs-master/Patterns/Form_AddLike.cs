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
    public partial class Form_AddLike : Form
    {
        public delegate void SavedHandler();
        public event SavedHandler Saved;
        bool save_btn_clicked = false;
        Product likeProduct;
        // Instantiate our undo/redo stack for operations on an integer value
        UndoRedoStack<Product> ur = new UndoRedoStack<Product>();
        ProductContext context = ProductContext.getProductContext();
        bool manuelChecked = true;

        public Form_AddLike(Product productToEdit)
        {
            InitializeComponent();
            likeProduct = productToEdit.clone();
            context.Products.Add(likeProduct);
            context.SaveChanges();
            createInterface();
            fillInterface();
        }

        private void createInterface()
        {
            if(likeProduct is Chair)
            {

            }
        }

        private void fillInterface()
        {
            comboBox_category.Items.AddRange(context.Categories.ToArray());
            comboBox_category.DisplayMember = "Name";

            textBox_name.Text = likeProduct.Name;
            comboBox_category.SelectedItem = context.Categories
                .Where(cat=>cat.CategoryId == likeProduct.CategoryId).ToList()[0];
            richTextBox_description.Text = likeProduct.Description;
            textBox_price.Text = likeProduct.Price.ToString();
            pictureBox_Image.Image = (Image)Properties.Resources.ResourceManager.GetObject(likeProduct.Image);

            //ProductContext dbContext = ProductContext.getProductContext();

            string styleStr = context.Styles.Where(style => style.StyleId == likeProduct.StyleId).ToList()[0].Name;
            pictureBox_Style.Image = (Image)Properties.Resources.ResourceManager.GetObject(styleStr);

            string materialStr = context.Materials.Where(mat => mat.MaterialId == likeProduct.MaterialId).ToList()[0].Name;
            pictureBox_Material.Image = (Image)Properties.Resources.ResourceManager.GetObject(materialStr);

            string newColorStr = context.Colors.Where(col => col.ColorOptionId == likeProduct.ColorId).ToList()[0].Name;
            label_Color.BackColor = Color.FromName(newColorStr);
            

         //   if (likeProduct is Chair)
          //  {
                
                if (likeProduct.Description.IndexOf("with arms") != -1)
                {
                    checkBox_Arms.Checked = true;
                }
                if (likeProduct.Description.IndexOf("with headboards") != -1)
                {
                    checkBox_HeadBoard.Checked = true;
                }
                
            //}
        }

       

        private void button_Undo_Click(object sender, EventArgs e)
        {
            likeProduct = ur.Undo((Product)likeProduct);
        }

        private void button_Redo_Click(object sender, EventArgs e)
        {
            likeProduct = ur.Redo((Product)likeProduct);
        }

        private void Form_likeProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Ctrl +z
        }

      

        private void label_Color_Click(object sender, EventArgs e)
        {
            //ProductContext dbContext = ProductContext.getProductContext();
            string colorStr = ((Label)sender).Tag.ToString();

            Color newColor = Color.FromName(colorStr);

            int newColorId = context.Colors.Where(color=> color.Name == colorStr).ToList()[0].ColorOptionId;
            int prevColorId = likeProduct.ColorId;

            ChangeColorCommand commandChangeColor = new ChangeColorCommand(newColorId, prevColorId);
            commandChangeColor.UndoEvent += CommandChangeColor_UndoDoEvent;
            commandChangeColor.DoEvent += CommandChangeColor_UndoDoEvent;
            likeProduct = ur.Do(commandChangeColor, likeProduct);
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
            int prevStyleId = likeProduct.StyleId;

            ChangeStyleCommand commandStyleChange = new ChangeStyleCommand(newStyleId, prevStyleId);
            commandStyleChange.UndoEvent += CommandStyleChange_UndoDoEvent;
            commandStyleChange.DoEvent += CommandStyleChange_UndoDoEvent;
            likeProduct = ur.Do(commandStyleChange, likeProduct);

            //pictureBox_Image.Image = (Image)Properties.Resources.ResourceManager.GetObject(likeProduct.Image);
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
            int prevMaterialId = likeProduct.MaterialId;

            ChangeMaterialCommand commandMaterialChange = new ChangeMaterialCommand(newMaterialId, prevMaterialId);
            commandMaterialChange.UndoEvent += CommandMaterialChange_UndoDoEvent;
            commandMaterialChange.DoEvent += CommandMaterialChange_UndoDoEvent;
            likeProduct = ur.Do(commandMaterialChange, likeProduct);

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
            //    likeProduct = new ArmsDecorator(likeProduct);
            //}
            //else likeProduct = ((ArmsDecorator)likeProduct).Wrappee;

            //else likeProduct = cmd.Undo(input);
            //likeProduct = new ArmsDecorator(likeProduct);
            if(manuelChecked)
                likeProduct = ur.Do(commandAddArms, likeProduct);
            
            //label_Description.Text = likeProduct.Description;
        }

        private void CommandAddArms_UndoDoEvent(bool value)
        {
            if (value && !checkBox_Arms.Checked  || !value && checkBox_Arms.Checked)
            {
                manuelChecked = false;
                checkBox_Arms.Checked = value;
                manuelChecked = true;
            }

            richTextBox_description.Text = likeProduct.Description;
        }

        private void checkBox_HeadBoard_CheckedChanged(object sender, EventArgs e)
        {
            AddHeadboardCommand commandAddHeadboard = new AddHeadboardCommand(checkBox_HeadBoard.Checked);
            commandAddHeadboard.UndoEvent += CommandAddHeadboard_UndoDoEvent;
            commandAddHeadboard.DoEvent += CommandAddHeadboard_UndoDoEvent;

            //likeProduct = new HeadBoardDecorator(likeProduct);
            if(manuelChecked)
                likeProduct = ur.Do(commandAddHeadboard, likeProduct);

            //label_Description.Text = likeProduct.Description;
        }

        private void CommandAddHeadboard_UndoDoEvent(bool value)
        {
            if (value && !checkBox_HeadBoard.Checked || !value && checkBox_HeadBoard.Checked)
            {
                manuelChecked = false;
                checkBox_HeadBoard.Checked = value;
                manuelChecked = true;
            }

            richTextBox_description.Text = likeProduct.Description;
        }
        

        private void button_SaveNew_Click(object sender, EventArgs e)
        {
            save_btn_clicked = true;
            likeProduct.Name = textBox_name.Text;
            likeProduct.CategoryId = ((Category)(comboBox_category.SelectedItem)).CategoryId;
            likeProduct.Category = (Category)(comboBox_category.SelectedItem);
            likeProduct.Price = Convert.ToDouble(textBox_price.Text);
            likeProduct.Description = richTextBox_description.Text;

            context.SaveChanges();
            this.Close();
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
                    likeProduct.Image = fileName;
                    //Properties.Resources.ResourceManager.A
                    context.SaveChanges();

                }
            }
        }


        private void Form_AddLike_Load(object sender, EventArgs e)
        {

        }

        private void Form_AddLike_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(save_btn_clicked == true)
            {
                Saved?.Invoke();
            }
            else
            {
                context.Products.Remove(likeProduct);
                context.SaveChanges();
            }
            
        }
    }
}
