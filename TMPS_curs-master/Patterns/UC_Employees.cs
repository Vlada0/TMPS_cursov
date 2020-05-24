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
    public partial class UC_Employees : UserControl
    {
        ProductContext dbContext;
        BindingSource bs = new BindingSource();
        public UC_Employees()
        {
            InitializeComponent();

            dbContext = ProductContext.getProductContext();

            dbContext.Components.Load();
            //dataGridView1.DataSource = new BindingList<Employee>(dbContext.Components.OfType<Employee>().ToList());
            //dbContext.Employees.Load();
            // dataGridView1.DataSource = dbContext.Employees.Local.ToBindingList<Employee>();
            //dataGridView1.DataSource = dbContext.Categories;
            bs.DataSource = new BindingList<Employee>(dbContext.Components.OfType<Employee>().ToList());
            dataGridView1.DataSource = bs;
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            button_Save_Changes.Enabled = true;
            dbContext.SaveChanges();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            button_Save_Changes.Enabled = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                button_Delete.Enabled = true;
            }
        }

        private void button_Save_Changes_Click(object sender, EventArgs e)
        {
            dbContext.SaveChanges();
            button_Save_Changes.Enabled = false;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(selectedRow);
                    dbContext.SaveChanges();
                }

                button_Save_Changes.Enabled = false;
            }
        }
    }
}
