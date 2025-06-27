using LayUI.Wpf.Enum;
using System.Globalization;
using System.Windows.Data;

namespace WPF.ComTool.Converters
{
    public class BoolToRippleType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out bool result))
            {
                return result ? RippleStyle.Auto : RippleStyle.Click;
            }
            return RippleStyle.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
