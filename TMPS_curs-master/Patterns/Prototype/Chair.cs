using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype
{
    public class Chair: Product
    {
        public bool HasBack { get; set; }


        public Chair(): base()
        {
            //CasingId = 0;
            HasBack = false;
        }

        public Chair(string name, int categoryId, string image, string description, int styleId, int colorId, int materialId,
            double price, int casingId, bool hasBack)
            :base(name, categoryId, image, description, styleId, colorId, materialId, price)
        {
            CasingId = casingId;
            HasBack = hasBack;

            //AvailableCasings = new List<CasingType> { CasingType.LEATHER, CasingType.TEXTILE, CasingType.RATTAN };
            //AvailableMaterials = new List<Material> { Material.METALL, Material.WOOD };
            //AvailableColors = new List<Color> { Color.Red, Color.Blue, Color.Black, Color.White };
        }


        // Pattern Prototype
        public Chair(Chair original): base(original)
        {
            //CasingId = original.CasingId;
            HasBack = original.HasBack;

            //AvailableCasings = new List<CasingType>(original.AvailableCasings);
        }

        
        public override Product clone()
        {
            return new Chair(this);
        }
    }
}
