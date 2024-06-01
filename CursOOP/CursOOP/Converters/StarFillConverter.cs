using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CursOOP.Converters;


    public class StarFillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = (bool)value;
            Color fillColor = isChecked ? Colors.Yellow : Colors.Black;
            return new SolidColorBrush(fillColor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
