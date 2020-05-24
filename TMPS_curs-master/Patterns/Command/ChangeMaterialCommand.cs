using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command
{
    class ChangeMaterialCommand : ICommand<Product>
    {
        public event UndoHandler UndoEvent;
        public event DoHandler DoEvent;

        private int newMaterialId;
        private int prevMaterialId;

        public int Material { get { return newMaterialId; } set { newMaterialId = value; } }

        public ChangeMaterialCommand()
        {
            newMaterialId = 0;
            prevMaterialId = 0;
        }

        public ChangeMaterialCommand(int nMaterialId, int prMaterialId)
        {
            newMaterialId = nMaterialId;
            prevMaterialId = prMaterialId;
        }



        public Product Do(Product input)
        {
            ProductContext dbContext = ProductContext.getProductContext();
            if (input.MaterialId != newMaterialId)
            {
                input.MaterialId = newMaterialId;
                dbContext.SaveChanges();

                DoEvent?.Invoke(newMaterialId);
            }
            return input;
        }

        public Product Undo(Product input)
        {
            ProductContext dbContext = ProductContext.getProductContext();
            input.MaterialId = prevMaterialId;
            dbContext.SaveChanges();

            UndoEvent?.Invoke(prevMaterialId);

            return input;
        }

    }
}
