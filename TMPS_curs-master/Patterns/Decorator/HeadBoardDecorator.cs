using Patterns.Model;
using Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class HeadBoardDecorator : BaseDecorator
    {
        public bool HasHeadboard { get; set; }
        public double PriceHeadboard { get; set; }

        ProductContext dbContext = ProductContext.getProductContext();

        public HeadBoardDecorator() : base()
        {
        }
        public HeadBoardDecorator(Product wrappee):base(wrappee)
        {
            PriceHeadboard = 200;
        }


        public override void addOption()
        {
            base.addOption();
            addExtra();
        }

        public void addExtra()
        {
            wrappee.Description += " with headboard";
            HasHeadboard = true;
            wrappee.Price += PriceHeadboard;

            dbContext.SaveChanges();
        }

        public override void removeOption()
        {
            base.removeOption();
            removeExtra();
        }

        private void removeExtra()
        {
            wrappee.Description = wrappee.Description.Replace(" with headboard", "");
            HasHeadboard = false;
            wrappee.Price -= PriceHeadboard;

            dbContext.SaveChanges();
        }

    }

    
}
