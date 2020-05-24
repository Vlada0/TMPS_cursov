using Patterns.Composite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Model
{
    public class Department: Component
    {
      //  [Key]
      //  public int DepartmentId { get; set; }

        // private readonly ObservableListSource<Employee> employees = new ObservableListSource<Employee>();
        // public virtual ObservableListSource<Employee> Employees { get { return employees; } }
        private readonly ObservableListSource<Component> employees = new ObservableListSource<Component>();
        public virtual ObservableListSource<Component> Employees { get { return employees; } }

        public Department()
        {
            Name = "";
            IsComposite = true;

        }

        public Department(string name/*, string image*/)
        {
            Name = name;
            IsComposite = true;
        }

        public override string ToString()
        {
            return Name;

        }

        //паттерн Композит

        public void AddEmployee(Component emp)
        {
            employees.Add(emp);
        }


        public void RemoveEmployee(Component emp)
        {
            employees.Remove(emp);
        }

        public List<Component> getEmployees()
        {
            ProductContext pContext = ProductContext.getProductContext();
            
            List<Component> list = new List<Component>();
           // List<Component> list = pContext.Employees.ToList().Where(emp => emp.DepartmentId == Id).ToList();
            list.AddRange(pContext.Employees.ToList().Where(emp => emp.DepartmentId == Id).ToList());
                
              
            /* if (Name == "Sale")
             {
                 list.ConvertAll(e=>(SaleEmployee)e);

             }
             else if(Name == "Montage")
             {
                 list.ConvertAll(e => (MontageEmployee)e);
             }
             else if (Name == "Storage")
             {
                 list.ConvertAll(e => (StorageEmployee)e);
             }*/
            return list;
        }
        public override void ProcessOrder(Order order)
        {
            foreach(var emp in getEmployees())
            {
                if (emp is Employee && ((Employee)emp).IsBusy == false)
                {
                    emp.ProcessOrder(order);
                    break;
                }
                    // //    if(emp is Employee && ((Employee)emp).IsBusy == false)
                    // //    {
                    ////         if (Name == "Sale" && emp is SaleEmployee)
                    ////         {
                    //             ((SaleEmployee)emp).ProcessOrder(order);
                    //             break;
                    //  //       }
                    // //    }
            }
        }
    }
}
