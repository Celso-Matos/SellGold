using System.Globalization;

namespace SellGold.Utils
{
    public class PriceIdToButtonTextConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || (value is Guid guid && guid == Guid.Empty))
                return "Adicionar";
            return "Editar";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();

    }
}
