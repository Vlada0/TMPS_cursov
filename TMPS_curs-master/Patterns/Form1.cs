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
    public partial class Form1 : Form
    {
        UC_Categories CategoriesUC;
        UC_Products ProductsUC;
        UC_Employees Employees_UC;
        UC_Orders Orders_UC;
        UC_Storage Storage_UC;
        UC_Clients Clients_UC;

        ProductContext dbContext;
        public Form1()
        {
            InitializeComponent();

            //dbContext = ProductContext.getProductContext();

           //tabControl_Main.SelectedIndex = 1;
           // tabControl_Main.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // можно в constr или в файл Program.cs
            Database.SetInitializer(new DBInitializer());
            dbContext = ProductContext.getProductContext();
            

            tabControl_Main.SelectedIndex = -1;
            tabControl_Main.SelectedIndex = 0;
        }

        private void tabControl_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl_Main.SelectedTab == tabPage_Products /*"Products"*/)
            {
                CategoriesUC = new UC_Categories();
                CategoriesUC.Dock = DockStyle.Fill;
                CategoriesUC.CategoryClick += CategoriesUC_CategoryClick;

                tabPage_Products.Controls.Clear();
                tabPage_Products.Controls.Add(CategoriesUC);
            }
            else if(tabControl_Main.SelectedTab == tabPage_Clients)
            {
                Clients_UC = new UC_Clients();
                Clients_UC.Dock = DockStyle.Fill;

                tabPage_Clients.Controls.Clear();
                tabPage_Clients.Controls.Add(Clients_UC);
            }
            else if (tabControl_Main.SelectedTab == tabPage_Store)
            {
                Storage_UC = new UC_Storage();
                Storage_UC.Dock = DockStyle.Fill;

                tabPage_Store.Controls.Clear();
                tabPage_Store.Controls.Add(Storage_UC);
            }
            else if(tabControl_Main.SelectedTab == tabPage_Orders)
            {
                Orders_UC = new UC_Orders();
                Orders_UC.Dock = DockStyle.Fill;

                tabPage_Orders.Controls.Clear();
                tabPage_Orders.Controls.Add(Orders_UC);
            }
            else if (tabControl_Main.SelectedTab == tabPage_Personal)
            {
                Employees_UC = new UC_Employees();
                Employees_UC.Dock = DockStyle.Fill;
                //Employees_UC.CategoryClick += CategoriesUC_CategoryClick;

                tabPage_Personal.Controls.Clear();
                tabPage_Personal.Controls.Add(Employees_UC);
            }
        }

        private void CategoriesUC_CategoryClick(object sender, EventArgs e)
        {
            ProductsUC = new UC_Products(((Button)sender).Text);
            ProductsUC.Dock = DockStyle.Fill;

            ProductsUC.BackClick += ProductsUC_BackClick;

            tabPage_Products.Controls.Clear();
            tabPage_Products.Controls.Add(ProductsUC);
        }

        private void ProductsUC_BackClick(object sender, EventArgs e)
        {
            tabPage_Products.Controls.Clear();
            tabPage_Products.Controls.Add(CategoriesUC);
        }
    }
}
