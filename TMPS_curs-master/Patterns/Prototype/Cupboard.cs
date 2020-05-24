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
    public class Cupboard : Product
    {
        //public int WoodId { get; set; }
        //public virtual Wood Wood { get; set; }
        //public List<int> AvailableWood { get; set; }
        ////private string availableWood;
        ////[NotMapped]
        ////public List<Wood> AvailableWood
        ////{
        ////    get
        ////    {
        ////        return availableWood.Split(';').ToList()
        ////          .ConvertAll(str => (Wood)Enum.Parse(typeof(Wood), str, true));
        ////    }
        ////    set { availableWood = string.Join($";", value); }
        ////}

        public int DoorsTypeId { get; set; }
        public virtual DoorsType DoorsTyp { get; set; }
        //public List<int> AvailableDoorsTyp { get; set; }
        ////private string availableDoorsTyp;
        ////[NotMapped]
        ////public List<DoorsTyp> AvailableDoorsTyp
        ////{
        ////    get
        ////    {
        ////        return availableDoorsTyp.Split(';').ToList()
        ////          .ConvertAll(str => (DoorsTyp)Enum.Parse(typeof(DoorsTyp), str, true));
        ////    }
        ////    set { availableDoorsTyp = string.Join($";", value); }
        ////}

        public Cupboard(): base()
        {
            //WoodId = 0;
            DoorsTypeId = 0;

            //AvailableWood = new List<int>();
            //AvailableDoorsTyp = new List<int>();
        }

        public Cupboard(string name, int categoryId, string image, string description, int styleId, int colorId, int materialId,
            double price, int woodId, int doorsTypeId)
            :base(name, categoryId, image, description, styleId, colorId, materialId, price)
        {
            WoodId = woodId;
            DoorsTypeId = doorsTypeId;

            //AvailableWood = new List<Wood> { Wood.MAPLE, Wood.ASH};
            //AvailableDoorsTyp = new List<DoorsTyp> { DoorsTyp.NORMAL, DoorsTyp.CUPE };
        }


        // Pattern Prototype
        public Cupboard(Cupboard original): base(original)
        {
            //WoodId = original.WoodId;
            DoorsTypeId = original.DoorsTypeId;

            //AvailableWood = new List<Wood>(original.AvailableWood);
            //AvailableDoorsTyp = new List<DoorsTyp>(original.AvailableDoorsTyp);
        }


        public override Product clone()
        {
            return new Cupboard(this);
        }
    }
}

