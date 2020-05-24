using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patterns
{
    public partial class UC_Personal : UserControl
    {
        public UC_Personal()
        {
            InitializeComponent();
            UC_Departments Departments_UC = new UC_Departments();
            Departments_UC.Dock = DockStyle.Fill;
            tabPage_Departments.Controls.Clear();
            tabPage_Departments.Controls.Add(Departments_UC);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage_Departments)
            {
                UC_Departments Departments_UC = new UC_Departments();
                Departments_UC.Dock = DockStyle.Fill;
                tabPage_Departments.Controls.Clear();
                tabPage_Departments.Controls.Add(Departments_UC);
            }
            else 
                if(tabControl1.SelectedTab == tabPage_Employees)
            {
                 UC_Employees Employees_UC = new UC_Employees();
                 Employees_UC.Dock = DockStyle.Fill;
                tabPage_Employees.Controls.Clear();
                tabPage_Employees.Controls.Add(Employees_UC);
            }
        }
    }
}
