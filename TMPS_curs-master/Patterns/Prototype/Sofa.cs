using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype
{
    public class Sofa : Product
    {
        //public CasingType Casing { get; set; }
        //public List<CasingType> AvailableCasings { get; set; }
        public bool HasArms { get; set; }

        public Sofa(): base()
        {
            //CasingId = 0;
            HasArms = false;
            //AvailableCasings = new List<CasingType>();
        }

        public Sofa(string name, int categoryId, string image, string description, int styleId, int colorId, int materialId,
            double price, int casingId, bool hasArms)
            :base(name, categoryId, image, description, styleId, colorId, materialId, price)
        {
            CasingId = casingId;
            HasArms = hasArms;

            //AvailableCasings = new List<CasingType> { CasingType.LEATHER, CasingType.TEXTILE };
            //AvailableMaterials = new List<Material> { Material.METALL, Material.WOOD };
            //AvailableColors = new List<Color> { Color.Gray, Color.Blue, Color.Black, Color.Beige };
        }


        // Pattern Prototype
        public Sofa(Sofa original): base(original)
        {
            //CasingId = original.CasingId;
            HasArms = original.HasArms;

            //AvailableCasings = new List<CasingType>(original.AvailableCasings);
        }


        public override Product clone()
        {
            return new Sofa(this);
        }
    }
}
