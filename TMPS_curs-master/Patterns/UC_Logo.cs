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

namespace Patterns
{
    public partial class UC_Logo : UserControl
    {
        public delegate void LoginCheckedHandler(bool loginSuccessful, Employee dbUser);
        public event LoginCheckedHandler LoginChecked;
        public UC_Logo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductContext context = ProductContext.getProductContext();
            List<Employee> employees = context.Employees.ToList();

            String password = employees.Where(em => em.Name.Replace(" ", "").ToLower() == textBox_login.Text.Replace(" ", "").ToLower()).ToList()[0].Password;
            if (password == null || password == "")
            {
                LoginChecked?.Invoke(false, null);
                return;
            }

            foreach (Employee employee in employees)
            {
                if (textBox_login.Text.Replace(" ", "").ToLower() == employee.Name.Replace(" ", "").ToLower())
                {
                    if (maskedTextBox_password.Text == employee.Password.ToString())
                    {
                         LoginChecked?.Invoke(true, employee);
                         return;
                    }
                }
            }
            LoginChecked?.Invoke(false, null);

        }
        public void Reset()
        {
            textBox_login.Text = "";
            maskedTextBox_password.Text = "";
        }

     
    }
}
