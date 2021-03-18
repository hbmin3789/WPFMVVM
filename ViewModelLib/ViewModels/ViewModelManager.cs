using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.Interfaces;
using ViewModelLib.Models;

namespace ViewModelLib.ViewModels
{
    public class ViewModelManager : INotifyPropertyChanged
    {
        #region Memeber

        public static IWindowService windowService;
        private Dictionary<Type, INotifyPropertyChanged> viewModelDict;

        #endregion



        #region Properties

        private INotifyPropertyChanged _currentViewModel;
        public INotifyPropertyChanged CurrentViewModel
        {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(nameof(CurrentViewModel)); }
        }

        private ObservableCollection<User> _userList;
        public ObservableCollection<User> UserList
        {
            get => _userList;
            set { _userList = value; OnPropertyChanged(nameof(UserList)); }
        }

        #endregion

        public ViewModelManager()
        {
            InitVariables();
            InitViewModels();
            ViewModelBase.viewModelManager = this;
        }

        private void InitVariables()
        {
            _userList = new ObservableCollection<User>();
            viewModelDict = new Dictionary<Type, INotifyPropertyChanged>();
        }

        private void InitViewModels()
        {
            viewModelDict.Add(typeof(UserListViewModel), new UserListViewModel());
            viewModelDict.Add(typeof(CustomControlsViewModel), new CustomControlsViewModel());

            CurrentViewModel = viewModelDict.First().Value;
        }

        public void SetCurrentViewModel<T>()
        {
            CurrentViewModel = viewModelDict[typeof(T)];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
