using Patterns.Decorator;
using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command
{
    public class AddArmsCommand: ICommand<Product>
    {
        public delegate void UndoHandler(bool value);
        public delegate void DoHandler(bool value);
        public event UndoHandler UndoEvent;
        public event DoHandler DoEvent;

        private bool hasArms;

        public bool HasArms { get { return hasArms; } set { hasArms = value; } }

        public AddArmsCommand()
        {
            hasArms = false;
        }

        public AddArmsCommand(bool hasarms)
        {
            hasArms = hasarms;
        }



        public Product Do(Product input)
        {
            // TODO ChangeImage
            ProductContext dbContext = ProductContext.getProductContext();
            input = new ArmsDecorator(input);
            if(hasArms)
                input.addOption();
            else input.removeOption();

            dbContext.SaveChanges();
            DoEvent?.Invoke(hasArms);

            if (hasArms)
                return ((ArmsDecorator)input).Wrappee;
            else
            {
                input = ((ArmsDecorator)input).Wrappee;
                return input;
            }
        }

        public Product Undo(Product input)
        {
            ProductContext dbContext = ProductContext.getProductContext();
            input = new ArmsDecorator(input);
            if (hasArms)
                input.removeOption();
            else
                input.addOption();

            dbContext.SaveChanges();
            UndoEvent?.Invoke(!hasArms);

            //return input;
            if(hasArms)
            {
                input = ((ArmsDecorator)input).Wrappee;
                return input;
            }
            else return ((ArmsDecorator)input).Wrappee;

        }
    }
}
