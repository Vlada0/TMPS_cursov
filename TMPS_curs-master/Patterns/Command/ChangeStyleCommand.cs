using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command
{
    class ChangeStyleCommand : ICommand<Product>
    {
        public event UndoHandler UndoEvent;
        public event DoHandler DoEvent;

        private int newStyleId;
        private int prevStyleId;

        public int Style { get { return newStyleId; } set { newStyleId = value; } }

        public ChangeStyleCommand()
        {
            newStyleId = 0;
            prevStyleId = 0;
        }

        public ChangeStyleCommand(int nStyleId, int prStyleId)
        {
            newStyleId = nStyleId;
            prevStyleId = prStyleId;
        }



        public Product Do(Product input)
        {
            ProductContext dbContext = ProductContext.getProductContext();

            if (input.StyleId != newStyleId)
            {
                input.StyleId = newStyleId;
                dbContext.SaveChanges();
                DoEvent?.Invoke(newStyleId);
            }
            return input;
        }

        public Product Undo(Product input)
        {
            ProductContext dbContext = ProductContext.getProductContext();
            input.StyleId = prevStyleId;
            dbContext.SaveChanges();

            UndoEvent?.Invoke(prevStyleId);
            
            return input;
        }

    }
}
