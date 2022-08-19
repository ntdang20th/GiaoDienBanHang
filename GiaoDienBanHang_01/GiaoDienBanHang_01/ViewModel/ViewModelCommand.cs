using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiaoDienBanHang_01.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //Các trường
        private readonly Action<object> _excuteAction;
        private readonly Predicate<object> _canExcuteAction;

        //Khởi tạo
        public ViewModelCommand(Action<object> excuteAction)
        {
            _excuteAction = excuteAction;
            _canExcuteAction = null;
        }

        public ViewModelCommand(Action<object> excuteAction, Predicate<object> canExcuteAction)
        {
            _excuteAction = excuteAction;
            _canExcuteAction = canExcuteAction;
        }

        //Sự kiện
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Phương thức
        public bool CanExecute(object parameter)
        {
            return _canExcuteAction == null ? true : _canExcuteAction(parameter);
        }

        public void Execute(object parameter)
        {
            _excuteAction(parameter);
        }
    }
}
