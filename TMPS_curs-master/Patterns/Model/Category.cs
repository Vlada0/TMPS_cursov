using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Model
{
    public class Category
    {
        

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        private readonly ObservableListSource<Product> products = new ObservableListSource<Product>();
        public virtual ObservableListSource<Product> Products { get { return products; } }


        public Category()
        {
            Name = "";
            Image = "";
        }

        public Category(string name, string image)
        {
            Name = name;
            Image = image;
        }
    }
}
