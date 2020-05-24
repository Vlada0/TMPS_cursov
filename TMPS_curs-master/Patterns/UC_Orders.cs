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
using Patterns.ChainOfResponsibility;

namespace Patterns
{
    // pattern Chain of Respons: class Client
    public partial class UC_Orders : UserControl
    {
        ProductContext dbContext;
        BindingSource bs = new BindingSource();
        public UC_Orders()
        {
            InitializeComponent();

            dbContext = ProductContext.getProductContext();
            dbContext.Orders.Load();
            //dataGridView_Orders.DataSource = dbContext.Orders.Local.ToBindingList<Order>();
            //dataGridView1.DataSource = dbContext.Categories;
            bs.DataSource = dbContext.Orders.Local.ToBindingList();
            dataGridView_Orders.DataSource = bs;
        }

        private void button_ProcessOrder_Click(object sender, EventArgs e)
        {

            if (dataGridView_Orders.SelectedRows != null)
            {
                foreach (DataGridViewRow selectedRow in dataGridView_Orders.SelectedRows)
                { 

                    string orderNumber = selectedRow.Cells[1].Value.ToString();

                //pattern Chain of Respons
                ProductContext pContext = ProductContext.getProductContext();

                SaleHandler saleHandler = new SaleHandler();
                MontageHandler montageHandler = new MontageHandler();
                StorageHandler storageHandler = new StorageHandler();

                Order selectedOrder = pContext.Orders.Where(order => order.OrderNumber == orderNumber).ToList()[0];
                for (int i = 0; i < selectedOrder.OrderProducts.Count; i++)
                {
                    // если в табл. StoreItems нет строки для selectedOrder.OrderProducts[i]
                    if (!(pContext.StoreItems.ToList().Exists(item => item.ProductID == selectedOrder.OrderProducts[i])))
                    {
                        saleHandler.setNext(montageHandler);
                        montageHandler.setNext(storageHandler);
                    }
                    else
                    {
                        int storeCount = pContext.StoreItems.ToList()
                            .Where(item => item.ProductID == selectedOrder.OrderProducts[i]).ToList<Store>()[0].ProductCount;
                        // если на складе меньше, чем в заказе
                        if (selectedOrder.OrderProductsCount[i] > storeCount)
                        {
                            saleHandler.setNext(montageHandler);
                            montageHandler.setNext(storageHandler);
                            break;
                        }
                        else
                        {
                            saleHandler.setNext(storageHandler);
                        }
                    }

                }
                saleHandler.handle(selectedOrder);
            }
            }

            dbContext.Orders.Load();
            dataGridView_Orders.DataSource = dbContext.Orders.Local.ToBindingList<Order>();

        }

        private void button_save_changes_Click(object sender, EventArgs e)
        {
            dbContext.SaveChanges();
            button_save_changes.Enabled = false;
        }

        private void button_delete_order_Click(object sender, EventArgs e)
        {
            if (dataGridView_Orders.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow selectedRow in dataGridView_Orders.SelectedRows)
                {
                    dataGridView_Orders.Rows.Remove(selectedRow);
                    dbContext.SaveChanges();
                }

                button_save_changes.Enabled = false;
            }

        }

        private void dataGridView_Orders_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Orders.SelectedRows.Count != 0)
            {
                button_delete_order.Enabled = true;
                button_Process.Enabled = true;
            }
        }


        private void dataGridView_Orders_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            button_save_changes.Enabled = true;
            dbContext.SaveChanges();
        }

        private void dataGridView_Orders_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            button_save_changes.Enabled = true;
        }

        private void dataGridView_Orders_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dbContext.SaveChanges();
        }
    }
}
