using Patterns.Composite;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Model
{
    //Singleton
    public class ProductContext: DbContext
    {
        // db tables
        public DbSet<Style> Styles { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ColorOption> Colors { get; set; }
        public DbSet<CasingType> CasingTypes { get; set; }
        public DbSet<Wood> Woods { get; set; }
        public DbSet<DoorsType> DoorTypes { get; set; }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Store> StoreItems { get; set; }

        public DbSet<Component> Components { get; set; }
        public List<Employee> Employees {
            get { return Components.ToList().Where(cmp => cmp.IsComposite == false).Cast<Employee>().ToList(); }
            set { }
        }
        public List<Department> Departments
        {
            get { return Components.ToList().Where(cmp => cmp.IsComposite == true).Cast<Department>().ToList(); }
            set { }
        }


        // singleton realization
        private static ProductContext productContext = null;
        private static readonly object lockObj = new object();

        private ProductContext():base("patterns") {
        }

        // свойство  
        public static ProductContext DBProductContext
        {
            get
            {
                lock (lockObj)
                {
                    if (productContext == null)
                    {
                        productContext = new ProductContext();
                    }
                    return productContext;
                }
            }
        }

        // метод
        public static ProductContext getProductContext()
        {
            lock (lockObj)
            {
                if (productContext == null)
                {
                    productContext = new ProductContext();
                }
                return productContext;
            }
        }
        ////////////////

        
        public static List<Product> getProductsByCategoryName(string categoryName)
        {
            return productContext.Categories.ToList().Where(c => c.Name == categoryName).ToList()[0].Products.ToList();
            //return productContext.Products.ToList().Where(p => p.Category.Name == categoryName).ToList();
        }
    }

    
}
