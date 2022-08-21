using FontAwesome.Sharp;
using GiaoDienBanHang_01.Model;
using GiaoDienBanHang_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GiaoDienBanHang_01.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        //fỉelds
        private UserModel _currentUserAccount;
        private IUserRepository userRepository;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public UserModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView { get => _currentChildView; set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        public string Caption { get => _caption; set { _caption = value; OnPropertyChanged(nameof(Caption)); }}
        public IconChar Icon { get => _icon; set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

        //Command
        public ICommand ShowHomeViewCommand { get; set; }
        public ICommand ShowCustomerViewCommand { get; set; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserModel();

             //Intitialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExcuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExcuteShowCustomerViewCommand);

            //default view
            ExcuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExcuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customer";
            Icon = IconChar.UserGroup;
        }

        private void ExcuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }


        //method
        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount = new UserModel()
                {
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }
            else
            {
                CurrentUserAccount.FirstName = "USer not logged in.";
            }
        }
    }
}
