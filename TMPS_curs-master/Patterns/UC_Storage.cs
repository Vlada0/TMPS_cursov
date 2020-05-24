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
    public partial class UC_Storage : UserControl
    {
        ProductContext dbContext = ProductContext.getProductContext();
        BindingSource bs = new BindingSource();
        public UC_Storage()
        {
            InitializeComponent();

            
            
            dbContext.StoreItems.Load();
            //dataGridView_StoreItems.DataSource = dbContext.StoreItems.Local.ToBindingList<Store>();
            //dataGridView1.DataSource = dbContext.Categories;

            

            //dbContext.StoreItems.Where(x=>x.SomeProperty == 2).Load();
            bs.DataSource = dbContext.StoreItems.Local.ToBindingList();
            dataGridView_StoreItems.DataSource = bs;
        }
        

        

        private void dataGridView_StoreItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_StoreItems.SelectedRows.Count != 0)
            {
                button_Delete.Enabled = true;
            }
        }

        private void dataGridView_StoreItems_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            button_Save.Enabled = true;
            dbContext.SaveChanges();
        }

        private void dataGridView_StoreItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            button_Save.Enabled = true;
        }

        private void dataGridView_StoreItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if(dataGridView_StoreItems.SelectedRows.Count != 0)
            {
                foreach(DataGridViewRow selectedRow in dataGridView_StoreItems.SelectedRows)
                {
                    dataGridView_StoreItems.Rows.Remove(selectedRow);
                    dbContext.SaveChanges();
                }

                button_Save.Enabled = false;
            }
            
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            dbContext.SaveChanges();
            button_Save.Enabled = false;
        }

        
    }
}
