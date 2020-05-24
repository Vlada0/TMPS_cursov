using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Model;

namespace Patterns.ChainOfResponsibility
{
    public class BaseHandler: IHandler
    {
        IHandler nextHandler;

        public void setNext(IHandler handler)
        {
            nextHandler = handler;
        }


        public virtual void handle(Order order)
        {
            if (nextHandler != null)
                nextHandler.handle(order);
        }

        
    }
}
