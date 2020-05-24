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
using System.Data.Entity;

namespace Patterns
{
    public partial class UC_Clients : UserControl
    {
        ProductContext dbContext;
        BindingSource bs = new BindingSource();
        public UC_Clients()
        {
            InitializeComponent();

            dbContext = ProductContext.getProductContext();
            dbContext.Clients.Load();
          //  dataGridView_Clients.DataSource = dbContext.Clients.Local.ToBindingList<Client>();
            //dataGridView1.DataSource = dbContext.Categories;
            bs.DataSource = dbContext.Clients.Local.ToBindingList();
            dataGridView_Clients.DataSource = bs;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            dbContext.SaveChanges();
            button_Add_Client.Enabled = false;
        }


        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_Clients.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow selectedRow in dataGridView_Clients.SelectedRows)
                {
                    dataGridView_Clients.Rows.Remove(selectedRow);
                    dbContext.SaveChanges();
                }

                button_Add_Client.Enabled = false;
            }
        }

        private void dataGridView_Clients_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Clients.SelectedRows.Count != 0)
            {
                button_Delete.Enabled = true;
            }
        }

        private void dataGridView_Clients_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            button_Add_Client.Enabled = true;
        }

        private void dataGridView_Clients_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void dataGridView_Clients_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            button_Add_Client.Enabled = true;
            dbContext.SaveChanges();
        }
    }
}
