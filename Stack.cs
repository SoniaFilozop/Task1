using System;
using System.Collections.Generic;

namespace StackApp
{
    public class CustomStack<T> where T : notnull
    {
        private readonly List<T> _items = new List<T>();
        private T? _topItem; 

        public CustomStack()
        {
            _topItem = default(T); 
        }

        public void Push(T item)
        {
            _items.Add(item);
            _topItem = item;
        }

        public T Pop()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            var item = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);

            if (_items.Count > 0)
                _topItem = _items[_items.Count - 1];
            else
                _topItem = default(T); 

            return item;
        }

        public void Clear()
        {
            _items.Clear();
            _topItem = default(T); 
        }

        public bool IsEmpty => _items.Count == 0;

        public int Count => _items.Count;

        public T TopItem
        {
            get
            {
                if (_items.Count == 0)
                    throw new InvalidOperationException("Stack is empty");

                return _topItem!;
            }
        }

        public List<T> ToList()
        {
            return new List<T>(_items);
        }
    }
}