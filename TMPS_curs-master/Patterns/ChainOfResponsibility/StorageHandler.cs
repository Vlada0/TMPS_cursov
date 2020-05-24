using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.ChainOfResponsibility
{
    public class StorageHandler:BaseHandler
    {
        public override void handle(Order order)
        {
            ProductContext pContext = ProductContext.getProductContext();
            if (canHandle(order))
            {
                Department storageDepartment = pContext.Departments.Where(dp => dp.Name == "Storage").ToList()[0];
                storageDepartment.ProcessOrder(order);

                base.handle(order);
            }
            else base.handle(order);

            pContext.SaveChanges();
        }

        private bool canHandle(Order order)
        {
            if (order.State.EndsWith("Montage ended;") || order.State.IndexOf("Price") != -1)
                return true;
            else return false;
        }
    }
}
