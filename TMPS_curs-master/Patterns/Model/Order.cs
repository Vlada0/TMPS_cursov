using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Model
{
    public class Order
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public string State { get; set; }
        

        private string orderProductsDb;
        public string OrderProductsDb { get { return orderProductsDb; } set { orderProductsDb = value; } }


        [NotMapped]
        private List<int> orderProducts;
        [NotMapped]
        public List<int> OrderProducts
        {
            get
            {
                if (orderProductsDb != "")
                    return orderProductsDb.Split(';').ToList()
                        .ConvertAll(str => Convert.ToInt32(str));
                return orderProducts;// new List<int>();
            }

            set
            {
                orderProductsDb = string.Join($";", value);
                orderProducts = new List<int>( value);
            }
        }



        private string orderProductsCountDb;
        public string OrderProductsCountDb { get { return orderProductsCountDb; } set { orderProductsCountDb = value; } }


        [NotMapped]
        private List<int> orderProductsCount;
        [NotMapped]
        public List<int> OrderProductsCount
        {
            get
            {
                if (orderProductsCountDb != "")
                    return orderProductsCountDb.Split(';').ToList()
                        .ConvertAll(str => Convert.ToInt32(str));
                return orderProductsCount;// new List<int>();
            }

            set
            {
                orderProductsCountDb = string.Join($";", value);
                orderProductsCount = new List<int>(value);
            }
        }



        public Order() { }

        public Order(string orderNumber, int clientId, string state, List<int> productsIds, List<int> productsCounts)
        {
            OrderNumber = orderNumber;
            ClientId = clientId;
            State = state;
            OrderProducts = productsIds;
            OrderProductsCount = productsCounts;
        }

    }
}
