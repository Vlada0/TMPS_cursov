using Patterns.Composite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Model
{
    public class Employee: Component
    {

       // [Key]
       // public int EmployeeId { get; set; }
        public string Password { get; set; }
        public bool IsBusy { get; set; }
        
        public double Salary { get; set; }

        // FK
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        ProductContext pContext = ProductContext.getProductContext();

        public Employee()
        {
            Name = "";
            DepartmentId = -1;
            IsBusy = false;
            Salary = 0;
            IsComposite = false;
        }

        public Employee(string name, string departmentName, string password,  double salary)
        {
            Name = name;
            Password = password;
            DepartmentId = pContext.Departments.ToList().Where(dp => dp.Name == departmentName).ToList()[0].Id;
            IsBusy = false;
            Salary = salary;
            IsComposite = false;
            
        }
        public Employee(string name, string departmentName, double salary)
        {
            Name = name;
            IsBusy = false;
            DepartmentId = pContext.Departments.ToList().Where(dp => dp.Name == departmentName).ToList()[0].Id;
            Salary = salary;
            IsComposite = false;
            
        }


        public override void ProcessOrder(Order order)
        {
            IsBusy = true;
            pContext.SaveChanges();


            string DepartmentName = pContext.Components.ToList().Where(cmp => cmp.Id == DepartmentId).ToList()[0].Name;
            if (DepartmentName == "Sale")
            {
                //
                double price = 0;
                foreach (int p in order.OrderProducts)
                {
                    price += pContext.Products.ToList().Where(pr => pr.ProductId == p).ToList()[0].Price;
                }
                order.State += " Price " + price.ToString() + ";";
                pContext.SaveChanges();
            }
            else if(DepartmentName == "Montage")
            {
                //
                order.State += " Montage ended;";

                int k = 0;
                foreach (int product in order.OrderProducts)
                {
                    int storeCount = pContext.StoreItems.ToList()
                               .Where(item => item.ProductID == product).ToList<Store>()[0].ProductCount;
                    if (storeCount < order.OrderProductsCount[k])
                        storeCount = order.OrderProductsCount[k];

                    pContext.StoreItems.ToList().Where(si => si.ProductID == product).ToList()[0].ProductCount = storeCount;
                    pContext.SaveChanges();

                    k++;
                }
                pContext.SaveChanges();
              
            }
            else if (DepartmentName == "Storage")
            {
                //
                order.State += " Sended";

                int k = 0;
                foreach (int product in order.OrderProducts)
                {
                    int storeCount = pContext.StoreItems.ToList()
                               .Where(item => item.ProductID == product).ToList<Store>()[0].ProductCount;
                    storeCount -= order.OrderProductsCount[k];

                    pContext.StoreItems.ToList().Where(si => si.ProductID == product).ToList()[0].ProductCount = storeCount;
                    pContext.SaveChanges();

                    k++;
                }
                pContext.SaveChanges();
            }

            IsBusy = false;
            pContext.SaveChanges();
        }
    }
}
