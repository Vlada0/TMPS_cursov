using Patterns.Model;
using Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class ArmsDecorator : BaseDecorator
    {
        public bool HasArms { get; set; }
        public double PriceArms { get; set; }

        ProductContext dbContext = ProductContext.getProductContext();

        public ArmsDecorator() : base()
        {
        }

        public ArmsDecorator(Product wrappee):base(wrappee)
        {
            PriceArms = 100;
        }


        public override void addOption()
        {
            base.addOption();
            addExtra();
        }

        private void addExtra()
        {
            wrappee.Description += " with arms";
            HasArms = true;
            wrappee.Price += PriceArms;

            dbContext.SaveChanges();
        }


        public override void removeOption()
        {
            base.removeOption();
            removeExtra();
        }

        private void removeExtra()
        {
            wrappee.Description = wrappee.Description.Replace(" with arms", "");
            HasArms = false;
            wrappee.Price -= PriceArms;

            dbContext.SaveChanges();
        }
    }

    
}
