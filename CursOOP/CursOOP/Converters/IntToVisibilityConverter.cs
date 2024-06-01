
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CursOOP.Converters;

    public class IntToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = (int)value;
            return number == 0 ? "" : number;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            return null;
        }
    }
