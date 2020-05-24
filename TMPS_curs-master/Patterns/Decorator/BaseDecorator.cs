using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class BaseDecorator: Product
    {
        protected Product wrappee;
        public Product Wrappee { get { return wrappee; } }

        public BaseDecorator() : base()
        {
        }

        public BaseDecorator(Product product)
        {
            wrappee = product;
        }

        public override void addOption()
        {
            wrappee.addOption();
        }

        public override void removeOption()
        {
            wrappee.removeOption();

        }

    }
}
