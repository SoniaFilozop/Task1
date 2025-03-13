using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using StackApp;

namespace BasicMvvmSample.ViewModels
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        private readonly CustomStack<object> _stack = new CustomStack<object>();

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

        public List<string> StackItems => _stack.ToList().Select(static x => x.ToString()).Reverse().ToList();

        public ICommand PushCommand { get; }
        public ICommand PopCommand { get; }
        public ICommand ClearCommand { get; }

        public SimpleViewModel()
        {
            PushCommand = new RelayCommand(Push);
            PopCommand = new RelayCommand(Pop);
            ClearCommand = new RelayCommand(Clear);
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
            if (_stack.Count > 0)
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

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;
        public void Execute(object? parameter) => _execute();

        public event EventHandler? CanExecuteChanged;
    }

}
