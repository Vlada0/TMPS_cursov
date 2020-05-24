using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.ChainOfResponsibility
{
    public class SaleHandler: BaseHandler
    {
        public override void handle(Order order)
        {
            ProductContext pContext = ProductContext.getProductContext();
            if (canHandle(order))
            {
                Department saleDepartment = pContext.Departments.Where(dp => dp.Name == "Sale").ToList()[0];
                saleDepartment.ProcessOrder(order);

                base.handle(order);
            }
            else base.handle(order);

            pContext.SaveChanges();
        }

        private bool canHandle(Order order)
        {
            if (order.State == "Received;")
                return true;
            else return false;
        }
    }
}
