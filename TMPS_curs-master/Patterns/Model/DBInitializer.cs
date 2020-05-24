using Patterns.Prototype;
using Patterns.Singleton;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Model
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges  <ProductContext> //DropCreateDatabaseAlways
    {
        //protected override void Seed(ProductContext context)
        //{
        //    Initialize(context);
        //}

        public DBInitializer()
        {
            ProductContext context = ProductContext.getProductContext();
            Initialize(context);
        }


        public static void Initialize(ProductContext dbContext)
        {
            //ProductContext dbContext = ProductContext.getProductContext();
            fillStyleTable(dbContext);
            fillMaterialTable(dbContext);
            fillCasingTypeTable(dbContext);
            fillWoodTable(dbContext);
            fillDoorTypeTable(dbContext);
            fillColorTable(dbContext);

            fillCategoryTable(dbContext);
            fillProductTable(dbContext);

            fillClientTable(dbContext);
            fillOrderTable(dbContext);
            fillStoreTable(dbContext);

            //fillEmploeesTable(dbContext);
            // fillDepartmentsTable(dbContext);
            fillComponentsTable(dbContext);
            //dbContext.SaveChanges();
        }

        private static void fillProductTable(ProductContext dbContext)
        {
            if (!dbContext.Products.Any())
            {
                dbContext.Products.AddRange(
                    new List<Product> {
                        new Table("Table1", 1, "table1", "This is a table", 1, 1, 1, 150, 3, true),
                        new Table("Table2", 1, "table2", "This is a table", 1, 5, 1, 180, 2, true),
                        new Table("Table3", 1, "table3", "This is a table", 2, 2, 1, 140, 1, false),

                        new Chair("Chair1", 2, "chair1", "This is a chair", 1, 1, 2, 60, 2, true),
                        new Chair("Chair2", 2, "chair2", "This is a chair", 2, 2, 1, 70, 1, true),
                        new Chair("Chair3", 2, "chair3", "This is a chair", 1, 1, 2, 50, 2, false),
                        new Chair("Chair4", 2, "chair4", "This is a chair", 2, 2, 1, 90, 3, false),

                        new Sofa("Sofa1", 3, "sofa1", "This is a sofa", 2, 2, 1, 400, 2, true),
                        new Sofa("Sofa2", 3, "sofa2", "This is a sofa", 1, 1, 1, 450, 1, false),
                        new Sofa("Sofa3", 3, "sofa3", "This is a sofa", 2, 2, 1, 500, 2, true),

                        new Armchair("Armchair1", 4, "armchair1", "This is a armchair", 1, 1, 1, 150, 2, true),
                        new Armchair("Armshair2", 4, "armchair2", "This is a armchair", 2, 2, 1, 160, 1, true),
                        new Armchair("Armshair3", 4, "armchair3", "This is a armchair", 1, 1, 1, 170, 2, false),
                        new Armchair("Armchair4", 4, "armchair4", "This is a armchair", 2, 2, 1, 200, 1, false),
                        new Armchair("Armchair5", 4, "armchair5", "This is a armchair", 2, 2, 1, 190, 2, false),

                        new Bed("Bed1", 5, "bed1", "This is a bed", 2, 2, 2, 500, 2, true),
                        new Bed("Bed2", 5, "bed2", "This is a bed", 1, 1, 1, 600, 2, false),
                        new Bed("Bed3", 5, "bed3", "This is a bed", 2, 2, 1, 700, 1, true),

                        new Cupboard("Cupboard1", 6, "cupboard1", "This is a cupboard", 2, 2, 1, 300, 1, 1),
                        new Cupboard("Cupboard2", 6, "cupboard2", "This is a cupboard", 1, 1, 1, 400, 2, 2),
                        new Cupboard("Cupboard3", 6, "cupboard3", "This is a cupboard", 2, 2, 1, 350, 1, 1),
                        new Cupboard("Cupboard4", 6, "cupboard4", "This is a cupboard", 2, 2, 1, 250, 1, 2),

                    }
                );
            }
            dbContext.SaveChanges();
        }


        private static void fillCategoryTable(ProductContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(
                    new List<Category> {
                        new Category("Table", "tables"),
                        new Category("Chair", "chairs"),
                        new Category("Sofa", "sofas"),
                        new Category("Armchair", "armchairs"),
                        new Category("Bed", "beds"),
                        new Category("Cupboard", "cupboards")
                    }
                );
            }
            dbContext.SaveChanges();
        }

        private static void fillOrderTable(ProductContext dbContext)
        {
            if (!dbContext.Orders.Any())
            {
                dbContext.Orders.AddRange(
                    new List<Order> {
                        new Order("111101", 1, "Received;", new List<int> { 1,2,5}, new List<int> { 1,2,1}),
                        new Order("111102", 1, "Received;", new List<int> { 1,3,4}, new List<int> { 1,1,1}),
                        new Order("111103", 2, "Received;", new List<int> { 1,3,4}, new List<int> { 1,2,2}),
                        new Order("111104", 2, "Received;", new List<int> { 1,2,4}, new List<int> { 1,3,1}),
                        new Order("111105", 2, "Received;", new List<int> { 5,6,7}, new List<int> { 1,2,1}),
                        new Order("111106", 3, "Received;", new List<int> { 4,6,5}, new List<int> { 1,1,1}),
                        new Order("111107", 4, "Received;", new List<int> { 5,4,7}, new List<int> { 1,2,1}),
                        new Order("111108", 4, "Received;", new List<int> { 5,4,7}, new List<int> { 2,2,2}),
                        new Order("111109", 5, "Received;", new List<int> { 3,4,4}, new List<int> { 1,2,1}),
                        new Order("111110", 5, "Received;", new List<int> { 5,3,7}, new List<int> { 1,2,2}),
                        new Order("111111", 5, "Received;", new List<int> { 1,4,7}, new List<int> { 1,3,1}),
                        new Order("111112", 1, "Received;", new List<int> { 5,1,7}, new List<int> { 1,2,3})
                    }
                );
            }
            //try { 
                dbContext.SaveChanges();
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            //{
            //    Exception raise = dbEx;
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            string message = string.Format("{0}:{1}",
            //                validationErrors.Entry.Entity.ToString(),
            //                validationError.ErrorMessage);
            //        // raise a new exception nesting
            //        // the current instance as InnerException
            //        raise = new InvalidOperationException(message, raise);
            //    }
            //}
            //    throw raise;
            //}

        }

        private static void fillClientTable(ProductContext dbContext)
        {
            if (!dbContext.Clients.Any())
            {
                dbContext.Clients.AddRange(
                    new List<Client> {
                        new Client("Client1", "email@gmail.com", "07645671"),
                        new Client("Client2", "email2@gmail.com", "07645672"),
                        new Client("Client3", "email3@gmail.com", "07645673"),
                        new Client("Client4", "email4@gmail.com", "07645674"),
                        new Client("Client5", "email5@gmail.com", "07645675"),
                        new Client("Client6", "email6@gmail.com", "07645676")
                    }
                );
            }
            dbContext.SaveChanges();
        }

        private static void fillStoreTable(ProductContext dbContext)
        {
            if (!dbContext.StoreItems.Any())
            {
                dbContext.StoreItems.AddRange(
                    new List<Store>
                    {
                        new Store(1, 10),
                        new Store(2, 11),
                        new Store(3, 0),
                        new Store(4, 5),
                        new Store(5, 1),
                        new Store(6, 0),
                        new Store(7, 10),
                        new Store(8, 2),
                        new Store(9, 3),
                        new Store(10, 1),
                    }    
                );
            }

            dbContext.SaveChanges();
        }


        // Options
        private static void fillColorTable(ProductContext dbContext)
        {
            if (!dbContext.Colors.Any())
            {
                dbContext.Colors.AddRange(
                   new List<ColorOption> {
                        new ColorOption("Black"),
                        new ColorOption("White"),
                        new ColorOption("Gray"),
                        new ColorOption("Brown"),
                        new ColorOption("Red"),
                        new ColorOption("Blue"),
                    }
                );
            }
            dbContext.SaveChanges();
        }

        private static void fillDoorTypeTable(ProductContext dbContext)
        {
            if (!dbContext.DoorTypes.Any())
            {
                dbContext.DoorTypes.AddRange(
                   new List<DoorsType> {
                        new DoorsType("normal"),
                        new DoorsType("cupe")
                    }
                );
            }

            dbContext.SaveChanges();
        }

        private static void fillWoodTable(ProductContext dbContext)
        {
            if (!dbContext.Woods.Any())
            {
                dbContext.Woods.AddRange(
                   new List<Wood> {
                        new Wood("oak"),
                        new Wood("ash"),
                        new Wood("maple")
                    }
                );
            }
            dbContext.SaveChanges();
        }

        private static void fillCasingTypeTable(ProductContext dbContext)
        {
            if (!dbContext.CasingTypes.Any())
            {
                dbContext.CasingTypes.AddRange(
                   new List<CasingType> {
                        new CasingType("textile"),
                        new CasingType("leather"),
                        new CasingType("rattan")
                    }
                );
            }
            dbContext.SaveChanges();
        }

        private static void fillMaterialTable(ProductContext dbContext)
        {
            if (!dbContext.Materials.Any())
            {
                dbContext.Materials.AddRange(
                   new List<Material> {
                        new Material("wood"),
                        new Material("metall")
                    }
                );
            }
            dbContext.SaveChanges();
        }

        private static void fillStyleTable(ProductContext dbContext)
        {
            if (!dbContext.Styles.Any())
            {
                dbContext.Styles.AddRange(
                   new List<Style> {
                        new Style("classic"),
                        new Style("modern"),
                        new Style("loft")
                    }
                );
            }
            dbContext.SaveChanges();
        }

        //Personal
        private static void fillDepartmentsTable(ProductContext dbContext)
        {
            if (!dbContext.Departments.Any())
            {
                dbContext.Departments.AddRange(
                   new List<Department> {
                        new Department("Management"),
                        new Department("HumanResources"),
                        new Department("Montage"),
                        new Department("Storage"),
                        new Department("Marketing"),
                        new Department("Sale"),
                    }
                );
            }
            dbContext.SaveChanges();
        }

        private static void fillEmploeesTable(ProductContext dbContext)
        {
            if (!dbContext.Employees.Any())
            {
                dbContext.Employees.AddRange(
                   new List<Employee> {
                        new Employee("Boss1", "Management","pass1", 5000),
                        new Employee("Boss2", "Management", "pass2", 4000),

                        new Employee("HR1", "HumanResources","passw1", 2000),
                        new Employee("HR2", "HumanResources","passw2",3000),

                        new Employee("Emp1", "Montage", "passw3",2000),
                        new Employee("Emp2", "Montage", "passw4",3000),
                        new Employee("Emp3", "Montage", "passw5",2500),
                        new Employee("Emp4", "Montage", "passw6",2000),
                        new Employee("Emp5", "Montage", "passw7",3000),
                        new Employee("Emp6", "Montage", "passw8",2500),
                        new Employee("Name1", "Montage","passw9", 2000),
                        new Employee("Name2", "Montage","passw10",3000),
                        new Employee("Name2", "Montage","passw11",2500),
                        
                        new Employee("Log1", "Storage", 2000),
                        new Employee("Log1", "Storage", 3000),
                        new Employee("Log1", "Storage", 2500),

                        new Employee("Mark1", "Marketing", 2000),
                        new Employee("Mark1", "Marketing", 3000),
                        new Employee("Mark1", "Marketing", 2500),

                        new Employee("Sale1", "Sale", 2000),
                        new Employee("Sale3", "Sale", 3000),
                        new Employee("Sale2", "Sale", 2500),

                    }
                );
            }
        }

        private static void fillComponentsTable(ProductContext dbContext)
        {
            if (!dbContext.Components.Any())
            {
                dbContext.Components.AddRange(
                   new List<Department> {
                        new Department("Management"),
                        new Department("HumanResources"),
                        new Department("Montage"),
                        new Department("Storage"),
                        new Department("Marketing"),
                        new Department("Sale"),
                    }
                );
                dbContext.SaveChanges();

                dbContext.Components.AddRange(
                   new List<Employee> {
                        new Employee("Boss1", "Management","pass1", 5000),
                        new Employee("Boss2", "Management", "pass2", 4000),

                        new Employee("HR1", "HumanResources","passw1", 2000),
                        new Employee("HR2", "HumanResources","passw2",3000),

                        new Employee("Emp1", "Montage", "passw3",2000),
                        new Employee("Emp2", "Montage", "passw4",3000),
                        new Employee("Emp3", "Montage", "passw5",2500),
                        new Employee("Emp4", "Montage", "passw6",2000),
                        new Employee("Emp5", "Montage", "passw7",3000),
                        new Employee("Emp6", "Montage", "passw8",2500),
                        new Employee("Name1", "Montage","passw9", 2000),
                        new Employee("Name2", "Montage","passw10",3000),
                        new Employee("Name2", "Montage","passw11",2500),

                        new Employee("Log1", "Storage", 2000),
                        new Employee("Log1", "Storage", 3000),
                        new Employee("Log1", "Storage", 2500),

                        new Employee("Mark1", "Marketing", 2000),
                        new Employee("Mark1", "Marketing", 3000),
                        new Employee("Mark1", "Marketing", 2500),

                        new Employee("Sale1", "Sale", 2000),
                        new Employee("Sale3", "Sale", 3000),
                        new Employee("Sale2", "Sale", 2500),

                    }
                );
            }
            dbContext.SaveChanges();
        }
    }
}
