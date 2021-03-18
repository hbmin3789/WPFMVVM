using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.Enumerables;

namespace ViewModelLib.Models
{
    public class User : INotifyPropertyChanged, ICloneable
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private int _age = 0;
        public int Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(nameof(Age)); }
        }

        private EGender _gender = EGender.male;
        public EGender Gender
        {
            get => _gender;
            set { _gender = value; OnPropertyChanged(nameof(Name)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            User user = new User();

            user.Name = this.Name;
            user.Gender = this.Gender;
            user.Age = this.Age;

            return user;
        }
    }
}
