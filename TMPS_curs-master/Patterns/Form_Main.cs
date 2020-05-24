using Patterns.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patterns
{
    public partial class Form_Main : Form
    {
        UC_Categories CategoriesUC;
        UC_Products ProductsUC;
        UC_Employees Employees_UC;
        UC_Orders Orders_UC;
        UC_Storage Storage_UC;
        UC_Clients Clients_UC;
        UC_Logo Logo_UC;
        UC_Statistic Statistic_UC;
        UC_Personal Personal_UC;

        ProductContext dbContext;


        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            // можно в constr или в файл Program.cs
            Database.SetInitializer(new DBInitializer());
            dbContext = ProductContext.getProductContext();

            button_main_Click(null, null);
        }

        private void button_products_Click(object sender, EventArgs e)
        {
            CategoriesUC = new UC_Categories();
            CategoriesUC.Dock = DockStyle.Fill;
            CategoriesUC.CategoryClick += CategoriesUC_CategoryClick;

            panel_userControl.Controls.Clear();
            panel_userControl.Controls.Add(CategoriesUC);
        }

        private void button_store_Click(object sender, EventArgs e)
        {
            Storage_UC = new UC_Storage();
            Storage_UC.Dock = DockStyle.Fill;

            panel_userControl.Controls.Clear();
            panel_userControl.Controls.Add(Storage_UC);
        }

        private void button_client_Click(object sender, EventArgs e)
        {
            Clients_UC = new UC_Clients();
            Clients_UC.Dock = DockStyle.Fill;

            panel_userControl.Controls.Clear();
            panel_userControl.Controls.Add(Clients_UC);
        }

        private void button_orders_Click(object sender, EventArgs e)
        {
            Orders_UC = new UC_Orders();
            Orders_UC.Dock = DockStyle.Fill;

            panel_userControl.Controls.Clear();
            panel_userControl.Controls.Add(Orders_UC);
        }

        private void button_personal_Click(object sender, EventArgs e)
        {
            Personal_UC = new UC_Personal();
            Personal_UC.Dock = DockStyle.Fill;



            panel_userControl.Controls.Clear();
            panel_userControl.Controls.Add(Personal_UC);
        }

        private void button_statistic_Click(object sender, EventArgs e)
        {
            Statistic_UC = new UC_Statistic();
            Statistic_UC.Dock = DockStyle.Fill;

            panel_userControl.Controls.Clear();
            panel_userControl.Controls.Add(Statistic_UC);
        }

        private void button_main_Click(object sender, EventArgs e)
        {
            Logo_UC = new UC_Logo();
            Logo_UC.Dock = DockStyle.Fill;
            Logo_UC.LoginChecked += Logo_UC_LoginChecked;

            panel_userControl.Controls.Clear();
            panel_userControl.Controls.Add(Logo_UC);
        }
        private void Logo_UC_LoginChecked(bool loginSuccessful, Employee dbUser)
        {
            if (loginSuccessful)
            {
                button_products.Enabled = true;
                button_client.Enabled = true;
                button_orders.Enabled = true;
                button_personal.Enabled = true;
                button_store.Enabled = true;
                button_statistic.Enabled = true;

                button_products_Click(null, null);
            }
            else
            {
                MessageBox.Show("Неправильно введен логин или пароль. Попробуйте еще раз!");
                Logo_UC.Reset();
            }

        }


        private void CategoriesUC_CategoryClick(object sender, EventArgs e)
        {
            ProductsUC = new UC_Products(((Button)sender).Text);
            ProductsUC.Dock = DockStyle.Fill;

            ProductsUC.BackClick += ProductsUC_BackClick;

            panel_userControl.Controls.Clear();
            panel_userControl.Controls.Add(ProductsUC);
        }
        private void ProductsUC_BackClick(object sender, EventArgs e)
        {
            panel_userControl.Controls.Clear();
            panel_userControl.Controls.Add(CategoriesUC);
        }

        
    }
}
