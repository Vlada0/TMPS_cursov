using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command
{
    public delegate void UndoHandler(int value);
    public delegate void DoHandler(int value);

    public interface ICommand<T>
    {
        T Do(T input);
        T Undo(T input);
    }
}
