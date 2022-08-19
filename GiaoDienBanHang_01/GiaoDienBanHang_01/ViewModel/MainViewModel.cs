using GiaoDienBanHang_01.Model;
using GiaoDienBanHang_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GiaoDienBanHang_01.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        //fỉelds
        private UserModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            LoadCurrentUserData();
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
                MessageBox.Show("Invalid user! Not logged in"); ;
                Application.Current.Shutdown();
            }
        }
    }
}
