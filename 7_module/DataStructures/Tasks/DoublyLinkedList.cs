using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Length { get; private set; }

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (tail == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
            }

            tail = newNode;
            Length++;
        }

        public void AddAt(int index, T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            else if (index == 0)
            {
                newNode.Next = head;

                if (head == null)
                {
                    tail = newNode;
                }
                else
                {
                    head.Previous = newNode;
                }

                head = newNode;
            }
            else if (index == Length)
            {
                if (tail == null)
                {
                    head = newNode;
                }
                else
                {
                    newNode.Previous = tail;
                    tail.Next = newNode;
                }

                tail = newNode;
            }
            else
            {
                Node<T> backNode = head;
                Node<T> forwardNode = tail;

                for (int i = -1; i < index - 2; i++)
                {
                    backNode = backNode.Next;
                }

                for (int i = Length - 1; i > index; i--)
                {
                    forwardNode = forwardNode.Previous;
                }

                backNode.Next = newNode;
                newNode.Previous = backNode;
                newNode.Next = forwardNode;
                forwardNode.Previous = newNode;
            }

            Length++;
        }

        public T ElementAt(int index)
        {
            Node<T> node = head;

            if (index < 0 || index > Length - 1)
            {
                throw new IndexOutOfRangeException("index");
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
            }

            return node.Data;
        }

        public void Remove(T item)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.ToString() == item.ToString())
                {
                    if (current.Next == null)
                    {
                        tail = current.Previous;
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (current.Previous == null)
                    {
                        head = current.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    current = null;
                    Length--;
                    break;
                }

                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            Node<T> removedNode = null;

            if (index < 0 || index > Length - 1 || Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                removedNode = head;
                head = removedNode.Next;
                head.Previous = null;
            }
            else if (index == Length - 1)
            {
                removedNode = tail;
                tail = removedNode.Previous;
                tail.Next = null;
            }
            else
            {
                Node<T> backNode = head;
                Node<T> forwardNode = tail;
                removedNode = backNode.Next;

                for (int i = 0; i < index - 1; i++)
                {
                    backNode = backNode.Next;
                    removedNode = backNode.Next;
                }

                for (int i = Length - 1; i > index + 1; i--)
                {
                    forwardNode = forwardNode.Previous;
                }

                backNode.Next = forwardNode;
                forwardNode.Previous = backNode;
            }

            Length--;
            return removedNode.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            List<T> list = new List<T>();

            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
