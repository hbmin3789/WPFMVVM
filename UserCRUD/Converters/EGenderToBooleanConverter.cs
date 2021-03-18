using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ViewModelLib.Enumerables;

namespace UserCRUD.Converters
{
    public class EGenderToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gender = (EGender)Enum.Parse(typeof(EGender), parameter.ToString());
            return gender == (EGender)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((bool)value)
            {
                return (EGender)Enum.Parse(typeof(EGender), parameter.ToString());
            }

            return Binding.DoNothing;
        }
    }
}
