using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Models;

namespace ViewModelLib.ViewModels
{
    public class CustomControlsViewModel : ViewModelBase
    {
        #region Properties
        public ObservableCollection<User> UserList
        {
            get => viewModelManager.UserList;
        }

        #endregion

        #region Commands

        public ICommand GotoUserListViewCommand { get; set; }

        #endregion

        public CustomControlsViewModel()
        {
            InitVariables();
            InitCommands();
        }

        #region Initialize

        private void InitVariables()
        {
        }

        private void InitCommands()
        {
            GotoUserListViewCommand = new MyCommand(GotoUserListView);
        }

        #endregion

        #region Command Methods

        private void GotoUserListView(object obj)
        {
            viewModelManager.SetCurrentViewModel<UserListViewModel>();
        }

        #endregion
    }
}
