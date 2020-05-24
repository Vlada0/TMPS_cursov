using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Composite
{
    public class StorageEmployee:Employee
    {
        ProductContext pContext = ProductContext.getProductContext();
        public override void ProcessOrder(Order order)
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
    }
}
