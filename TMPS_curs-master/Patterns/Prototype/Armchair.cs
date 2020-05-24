using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype
{
    public class Armchair : Product
    {
        //public CasingType Casing { get; set; }
        //public List<CasingType> AvailableCasings { get; set; }
        public bool HasArms { get; set; }

        public Armchair(): base()
        {
            //CasingId = 0;
            HasArms = false;
        }

        public Armchair(string name, int categoryId, string image, string description, int styleId, int colorId, int materialId,
            double price, int casingId, bool hasArms)
            :base(name, categoryId, image, description, styleId, colorId, materialId, price)
        {
            CasingId = casingId;
            HasArms = hasArms;

            //AvailableCasings = new List<CasingType> { CasingType.LEATHER, CasingType.TEXTILE, CasingType.RATTAN };
            //AvailableMaterials = new List<Material> { Material.METALL, Material.WOOD };
            //AvailableColors = new List<Color> { Color.Gray, Color.Blue, Color.Black, Color.Beige };
        }


        // Pattern Prototype
        public Armchair(Armchair original): base(original)
        {
            //CasingId = original.CasingId;
            HasArms = original.HasArms;

            //AvailableCasings = new List<CasingType>(original.AvailableCasings);
        }


        public override Product clone()
        {
            return new Armchair(this);
        }
    }
}
