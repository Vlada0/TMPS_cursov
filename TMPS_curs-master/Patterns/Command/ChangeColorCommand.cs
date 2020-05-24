using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command
{
    class ChangeColorCommand : ICommand<Product>
    {
        public event UndoHandler UndoEvent;
        public event DoHandler DoEvent;

        private int newColorId;
        private int prevColorId;

        public int Color { get { return newColorId; } set { newColorId = value; } }

        public ChangeColorCommand()
        {
            newColorId = 0;// Color.FromKnownColor(KnownColor.Black);
            prevColorId = 0;// Color.FromKnownColor(KnownColor.Black);
        }

        public ChangeColorCommand(int nColor, int prColor)
        {
            newColorId = nColor;
            prevColorId = prColor;
        }



        public Product Do(Product input)
        {
            // TODO ChangeImage
            ProductContext dbContext = ProductContext.getProductContext();
            if (input.ColorId != newColorId)
            {
                input.ColorId = newColorId;
                dbContext.SaveChanges();

                DoEvent?.Invoke(newColorId);
            }

            return input;
        }

        public Product Undo(Product input)
        {
            ProductContext dbContext = ProductContext.getProductContext();
            input.ColorId = prevColorId;
            dbContext.SaveChanges();

            UndoEvent?.Invoke(prevColorId);
            return input;
        }

    }
}
