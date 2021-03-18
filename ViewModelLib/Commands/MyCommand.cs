using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModelLib.Commands
{
    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> _executeCommand;
        Func<object, bool> _canExecuteCommand;

        public MyCommand(Action<object> executeCommand, Func<object, bool> canExecuteCommand = null)
        {
            _executeCommand = executeCommand;
            _canExecuteCommand = canExecuteCommand;
        }

        public bool CanExecute(object parameter)
        {
            if(_canExecuteCommand == null)
            {
                return true;
            }
            return _canExecuteCommand(parameter);
        }

        public void Execute(object parameter)
        {
            _executeCommand(parameter);
        }
    }
}
