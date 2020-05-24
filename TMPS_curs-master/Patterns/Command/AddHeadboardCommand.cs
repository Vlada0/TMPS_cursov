using Patterns.Decorator;
using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command
{
    public class AddHeadboardCommand: ICommand<Product>
    {
        public delegate void UndoHandler(bool value);
        public delegate void DoHandler(bool value);
        public event UndoHandler UndoEvent;
        public event DoHandler DoEvent;

        private bool hasHeadboard;

        public bool HasHeadboard { get { return hasHeadboard; } set { hasHeadboard = value; } }

        public AddHeadboardCommand()
        {
            hasHeadboard = false;
        }

        public AddHeadboardCommand(bool hasheadboard)
        {
            hasHeadboard = hasheadboard;
        }



        public Product Do(Product input)
        {
            // TODO ChangeImage
            ProductContext dbContext = ProductContext.getProductContext();
            input = new HeadBoardDecorator(input);
            //input.addOption();
            if (hasHeadboard)
                input.addOption();
            else input.removeOption();

            dbContext.SaveChanges();
            DoEvent?.Invoke(hasHeadboard);


            //return input;
            //return ((HeadBoardDecorator)input).Wrappee;
            if (hasHeadboard)
                return ((HeadBoardDecorator)input).Wrappee;
            else
            {
                input = ((HeadBoardDecorator)input).Wrappee;
                return input;
            }
        }

        public Product Undo(Product input)
        {
            ProductContext dbContext = ProductContext.getProductContext();
            input = new HeadBoardDecorator(input);
            //input.removeOption();
            if (hasHeadboard)
                input.removeOption();
            else
                input.addOption();

            dbContext.SaveChanges();
            UndoEvent?.Invoke(!hasHeadboard);

            //return input;
            //return ((HeadBoardDecorator)input).Wrappee;
            if (hasHeadboard)
            {
                input = ((HeadBoardDecorator)input).Wrappee;
                return input;
            }
            else return ((HeadBoardDecorator)input).Wrappee;
        }
    }
}
