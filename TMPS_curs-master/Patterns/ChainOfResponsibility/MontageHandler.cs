using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.ChainOfResponsibility
{
    public class MontageHandler: BaseHandler
    {
        public override void handle(Order order)
        {
            ProductContext pContext = ProductContext.getProductContext();
            if (canHandle(order))
            {
                Department montageDepartment = pContext.Departments.Where(dp => dp.Name == "Montage").ToList()[0];
                montageDepartment.ProcessOrder(order);  
                base.handle(order);
            }
            else base.handle(order);

            pContext.SaveChanges();
        }

        private bool canHandle(Order order)
        {
            if (order.State.IndexOf("Price") != -1)
                return true;
            else return false;
        }
    }
}
