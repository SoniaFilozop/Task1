using System;
using System.Collections.Generic;

namespace StackApp
{
    // Используем модификаторы nullable
    public class CustomStack<T> where T : notnull
    {
        private readonly List<T> _items = new List<T>();
        private T? _topItem; // Добавим поддержку nullable

        // Конструктор
        public CustomStack()
        {
            _topItem = default(T); // Инициализация верхнего элемента
        }

        // Добавление элемента в вершину стека
        public void Push(T item)
        {
            _items.Add(item);
            _topItem = item; // Обновляем верхний элемент
        }

        // Удаление элемента с вершины стека
        public T Pop()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            var item = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);

            // Обновляем верхний элемент, если стек не пуст
            if (_items.Count > 0)
                _topItem = _items[_items.Count - 1];
            else
                _topItem = default(T); // Если стек пуст, установить null или значение по умолчанию

            return item;
        }

        // Очистка стека
        public void Clear()
        {
            _items.Clear();
            _topItem = default(T); // Обнуляем верхний элемент
        }

        // Проверка на пустоту стека
        public bool IsEmpty => _items.Count == 0;

        // Текущее количество элементов в стеке
        public int Count => _items.Count;

        // Свойство для получения верхнего элемента стека
        public T TopItem
        {
            get
            {
                if (_items.Count == 0)
                    throw new InvalidOperationException("Stack is empty");

                return _topItem!;
            }
        }

        // Преобразование стека в список
        public List<T> ToList()
        {
            return new List<T>(_items);
        }
    }
}