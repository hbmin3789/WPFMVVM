using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Enumerables;
using ViewModelLib.Models;

namespace ViewModelLib.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        #region Properties

        public ObservableCollection<User> UserList
        {
            get => viewModelManager.UserList;
        }

        private User _addingUser;
        public User AddingUser
        {
            get => _addingUser;
            set { _addingUser = value; OnPropertyChanged(nameof(AddingUser)); }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged(nameof(SelectedUser)); }
        }

        private User _editingUser;
        public User EditingUser
        {
            get => _editingUser;
            set { _editingUser = value; OnPropertyChanged(nameof(EditingUser)); }
        }

        private bool _userEditViewVisibility;
        public bool UserEditViewVisibility
        {
            get => _userEditViewVisibility;
            set { _userEditViewVisibility = value; OnPropertyChanged(nameof(UserEditViewVisibility)); }
        }

        private ELanguages _currentLang = ELanguages.Korean;
        public ELanguages CurrentLang
        {
            get => _currentLang;
            set 
            {
                _currentLang = value;
                OnPropertyChanged(nameof(CurrentLang));
                ViewModelManager.windowService.SetLanguage(value);
            }
        }

        #endregion

        #region Commands

        public ICommand AddUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand UpdateUserCommand { get; set; }

        public ICommand ConfirmEditUserCommand { get; set; }
        public ICommand CancelEditUserCommand { get; set; }

        public ICommand GotoCustomControlPageCommand { get; set; }

        #endregion

        public UserListViewModel()
        {
            InitVariables();
            InitCommands();
        }

        #region Initialize

        private void InitVariables()
        {
            _addingUser = new User();
        }

        private void InitCommands()
        {
            AddUserCommand = new MyCommand(AddUser);
            DeleteUserCommand = new MyCommand(DeleteUser);
            UpdateUserCommand = new MyCommand(UpdateUser);

            ConfirmEditUserCommand = new MyCommand(ConfirmEditUser);
            CancelEditUserCommand = new MyCommand(CancelEditUser);

            GotoCustomControlPageCommand = new MyCommand(GotoCustomControlPage);
        }

        #endregion

        #region Command Methods

        private void AddUser(object parameter)
        {
            UserList.Add(AddingUser.Clone() as User);
        }

        private void UpdateUser(object obj)
        {
            if (SelectedUser !=  null)
            {
                UserEditViewVisibility = true;
                EditingUser = SelectedUser.Clone() as User;
            }
        }
         
        private void DeleteUser(object obj)
        {
            if (SelectedUser != null)
            {
                UserList.Remove(SelectedUser);
            }
        }

        private void ConfirmEditUser(object obj)
        {
            if(EditingUser.Name.Length > 0)
            {
                UserList[UserList.IndexOf(SelectedUser)] = EditingUser.Clone() as User;
                UserEditViewVisibility = false;
            }
        }

        private void CancelEditUser(object obj)
        {
            UserEditViewVisibility = false;
        }

        private void GotoCustomControlPage(object obj)
        {
            viewModelManager.SetCurrentViewModel<CustomControlsViewModel>();
        }

        #endregion
    }
}
