using System;

namespace StackApp
{
    public class Node<T>
    {
        public T Data { get; }
        public Node<T>? Next { get; }

        public Node(T data, Node<T>? next)
        {
            Data = data;
            Next = next;
        }
    }

    public class CustomStack<T> where T : notnull
    {
        private Node<T>? _top;
        private int _count;

        public CustomStack()
        {
            _top = null;
            _count = 0;
        }

        public void Push(T item)
        {
            _top = new Node<T>(item, _top);
            _count++;
        }

        public T Pop()
        {
            if (_top == null)
                throw new InvalidOperationException("Stack is empty");

            T item = _top.Data;
            _top = _top.Next;
            _count--;

            return item;
        }

        public void Clear()
        {
            _top = null;
            _count = 0;
        }

        public bool IsEmpty => _top == null;

        public int Count => _count;

        public T TopItem
        {
            get
            {
                if (_top == null)
                    throw new InvalidOperationException("Stack is empty");

                return _top.Data;
            }
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];
            Node<T>? current = _top;
            int index = _count - 1;

            while (current != null)
            {
                result[index--] = current.Data;
                current = current.Next;
            }

            return result;
        }
    }
}
