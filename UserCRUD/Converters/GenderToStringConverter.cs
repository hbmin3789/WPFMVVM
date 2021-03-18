using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UserCRUD.Converters
{
    public class GenderToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = "UserGender*String";
            var gender = value.ToString();
            gender = gender[0].ToString().ToUpper() + gender.Substring(1, gender.Length - 1);

            key = key.Replace("*", gender);
            return App.Current.Resources[key];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
