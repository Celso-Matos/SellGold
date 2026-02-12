using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SellGold.Utils
{
    class EqualityConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value?.ToString() == parameter?.ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return null;
            return (bool)value ? parameter : null;
        }
    }
}
