using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Model
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int ProductCount { get; set; }

        public Store() { }

        public Store(int productID, int count)
        {
            ProductID = productID;
            ProductCount = count;
        }
    }
}
