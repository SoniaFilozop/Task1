using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ReactiveUI;
using StackApp;

namespace BasicMvvmSample.ViewModels
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        private readonly CustomStack<string> _stack = new CustomStack<string>();

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string? _valueData;
        public string? ValueData
        {
            get => _valueData;
            set
            {
                if (_valueData != value)
                {
                    _valueData = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(StackItems));
                }
            }
        }

        public List<string> StackItems => _stack.ToArray().Reverse().ToList();

        public ICommand PushCommand { get; }
        public ICommand PopCommand { get; }
        public ICommand ClearCommand { get; }

        public SimpleViewModel()
        {
            PushCommand = ReactiveCommand.Create(Push);
            PopCommand = ReactiveCommand.Create(Pop);
            ClearCommand = ReactiveCommand.Create(Clear);
        }


        private void Push()
        {
            if (!string.IsNullOrWhiteSpace(ValueData))
            {
                _stack.Push(ValueData);
                RaisePropertyChanged(nameof(StackItems));
            }
        }

        private void Pop()
        {
            if (!_stack.IsEmpty)
            {
                _stack.Pop();
                RaisePropertyChanged(nameof(StackItems));
            }
        }

        private void Clear()
        {
            _stack.Clear();
            RaisePropertyChanged(nameof(StackItems));
        }
    }
}
