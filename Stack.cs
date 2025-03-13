using System;
using System.Collections.Generic;

namespace StackApp
{
    public class CustomStack<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Push(T item)
        {
            _items.Add(item);
        }

        public T Pop()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            var item = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);
            return item;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool IsEmpty => _items.Count == 0;

        public int Count => _items.Count;

        public List<T> ToList()
        {
            return new List<T>(_items);
        }
    }
}