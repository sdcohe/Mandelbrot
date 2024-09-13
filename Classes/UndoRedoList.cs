using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot.Classes
{
    public class UndoRedoList<T>
    {
        private List<T> list;
        private int currentIndex = -1;

        public UndoRedoList()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
            currentIndex = list.Count - 1;
        }

        public T CurrentItem()
        {
            if (list.Count > 0)
            {
                return list[currentIndex];
            }
            else
            {
                throw new IndexOutOfRangeException("List is empty");
            }
        }

        public int CurrentIndex()
        {
            return currentIndex;
        }

        public T Undo()
        {
            if (list.Count > 1 && currentIndex > 0)
            {
                currentIndex--;
                return list[currentIndex];
            }
            else
            {
                throw new IndexOutOfRangeException("List is empty or no prior elements");
            }
        }

        public T Redo()
        {
            if (list.Count > 1 && currentIndex < list.Count - 1)
            {
                currentIndex++;
                return list[currentIndex];
            }
            else
            {
                throw new IndexOutOfRangeException("List is empty or no subsequent elements");
            }
        }

        public bool UndoPossible()
        {
            return list.Count > 1 && currentIndex > 0;
        }

        public bool RedoPossible()
        {
            return list.Count > 1 && currentIndex < list.Count - 1;
        }

        public void Reset()
        {
            currentIndex = -1;
            list.Clear();
        }

        public IList<T> Items()
        {
            return list.AsReadOnly();
        }
    }
}
