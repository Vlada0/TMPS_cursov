using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command
{
    public class UndoRedoStack<T>
    {
        public delegate void UndoRedoCountChangedHandler(string action, bool enable);
        public event UndoRedoCountChangedHandler UndoRedoCountChanged; 


        private Stack<ICommand<T>> _Undo;
        private Stack<ICommand<T>> _Redo;

        public int UndoCount{get  { return _Undo.Count; } }
        public int RedoCount  {  get  { return _Redo.Count; } }


        public UndoRedoStack()
        {
            Reset();
        }
        public void Reset()
        {
            _Undo = new Stack<ICommand<T>>();
            _Redo = new Stack<ICommand<T>>();
        }



        public T Do(ICommand<T> cmd, T input)
        {
            T output = cmd.Do(input);
            _Undo.Push(cmd);
            _Redo.Clear(); // Once we issue a new command, the redo stack clears
            //enable Undo
            UndoRedoCountChanged?.Invoke("undo", true);
            return output;
        }

        public T Undo(T input)
        {
            if (_Undo.Count > 0)
            {
                ICommand<T> cmd = _Undo.Pop();
                T output = cmd.Undo(input);
                _Redo.Push(cmd);
                // enable Redo
                UndoRedoCountChanged?.Invoke("redo", true);
                if (_Undo.Count == 0)
                    UndoRedoCountChanged?.Invoke("undo", false);

                return output;
            }
            else
            {
                // disable Undo
                UndoRedoCountChanged?.Invoke("undo", false);
                return input;
            }
        }

        public T Redo(T input)
        {
            if (_Redo.Count > 0)
            {
                ICommand<T> cmd = _Redo.Pop();
                T output = cmd.Do(input);
                _Undo.Push(cmd);
                //enable Undo
                UndoRedoCountChanged?.Invoke("undo", true);
                if (_Redo.Count == 0)
                    UndoRedoCountChanged?.Invoke("redo", false);

                return output;
            }
            else
            {
                //disable Redo
                UndoRedoCountChanged?.Invoke("redo", false);
                return input;
            }
        }


    }
}
