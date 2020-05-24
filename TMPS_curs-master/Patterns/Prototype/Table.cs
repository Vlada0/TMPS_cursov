using Patterns.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype
{
    public class Table : Product
    {
        //public int WoodId { get; set; }
        //public virtual Wood Wood { get; set; }

        //private string availableWood;
        ////public List<Wood> AvailableWood { get; set; }
        //[NotMapped]
        //public List<Wood> AvailableWood
        //{
        //    get
        //    {
        //        return availableWood.Split(';').ToList()
        //          .ConvertAll(str => (Wood)Enum.Parse(typeof(Wood), str, true));
        //    }
        //    set { availableWood = string.Join($";", value); }
        //}

        public bool IsFolding { get; set; }

        public Table(): base()
        {
            //WoodId = 0;
            IsFolding = false;

            //AvailableWood = new List<Wood>();
        }

        public Table(string name, int categoryId, string image, string description, int styleId, int colorId, int materialId,
            double price, int woodId, bool isFolding)
            :base(name, categoryId, image, description, styleId, colorId, materialId, price)
        {
            WoodId = woodId;
            IsFolding = isFolding;

            //AvailableWood = new List<Wood> { Wood.OAK, Wood.MAPLE };
            //AvailableMaterials = new List<Material> { Material.METALL, Material.WOOD };
            //AvailableColors = new List<Color> { Color.Gray, Color.Black, Color.Beige };
        }


        // Pattern Prototype
        public Table(Table original): base(original)
        {
            //WoodId = original.WoodId;
            IsFolding = original.IsFolding;

            //AvailableWood = new List<Wood>(original.AvailableWood);
        }


        public override Product clone()
        {
            return new Table(this);
        }
    }
}

