using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Composite
{
    public class SaleEmployee:Employee
    {
        ProductContext pContext = ProductContext.getProductContext();

        public override void ProcessOrder(Order order)
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
    }
}
