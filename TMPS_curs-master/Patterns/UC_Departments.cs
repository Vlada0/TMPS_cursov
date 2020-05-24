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
    public partial class UC_Departments : UserControl
    {
        public UC_Departments()
        {
            InitializeComponent();

            ProductContext dbContext = ProductContext.getProductContext();
            // dbContext.Departments.Load();
            // dataGridView1.DataSource = dbContext.Departments.Local.ToBindingList<Department>();
            dbContext.Components.Load();
            dataGridView1.DataSource = new BindingList<Department>(dbContext.Components.OfType<Department>().ToList());
            // Local.Where(cmp => !cmp.IsComposite).ToBindingList();
            //dataGridView1.DataSource = (from m in dbContext.Components
            //                              where m.IsComposite
            //                  select m).ToList<TYPE>();
            //dataGridView1.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            //= dbContext.Components.Where(cmp=>cmp.IsComposite==true);

        }
    }
}
