using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> linkedList = new DoublyLinkedList<T>();
        public T Dequeue()
        {
            if (linkedList.Length == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return linkedList.RemoveAt(0);
            }
        }

        public void Enqueue(T item)
        {
            linkedList.Add(item);
        }

        public T Pop()
        {
            if (linkedList.Length == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return linkedList.RemoveAt(0);
            }
        }

        public void Push(T item)
        {
            linkedList.AddAt(0, item);
        }
    }
}
