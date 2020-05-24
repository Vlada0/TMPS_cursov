using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Composite
{
   public class MontageEmployee:Employee
    {
        ProductContext pContext = ProductContext.getProductContext();
        public override void ProcessOrder(Order order)
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
    }
}
