using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype
{
    public class Bed : Product
    {
        public bool HasHeadrest { get; set; }

        public Bed(): base()
        {
            //CasingId = 0;
            HasHeadrest = true;
        }

        public Bed(string name, int categoryId, string image, string description, int styleId, int colorId, int materialId,
            double price, int casingId, bool hasHeadrest)
            :base(name, categoryId, image, description, styleId, colorId, materialId, price)
        {
            CasingId = casingId;
            HasHeadrest = hasHeadrest;

            //AvailableCasings = new List<CasingType> { CasingType.LEATHER, CasingType.TEXTILE };
            //AvailableMaterials = new List<Material> { Material.METALL, Material.WOOD };
            //AvailableColors = new List<Color> { Color.Gray, Color.Blue, Color.Black, Color.Beige };
        }


        // Pattern Prototype
        public Bed(Bed original): base(original)
        {
            //CasingId = original.CasingId;
            HasHeadrest = original.HasHeadrest;

            //AvailableCasings = new List<CasingType>(original.AvailableCasings);
        }


        public override Product clone()
        {
            return new Bed(this);
        }
    }
}
