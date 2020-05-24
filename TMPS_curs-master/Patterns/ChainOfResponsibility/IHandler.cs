using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.ChainOfResponsibility
{
    public interface IHandler
    {
        void setNext(IHandler handler);
        void handle(Order order);
    }
}
