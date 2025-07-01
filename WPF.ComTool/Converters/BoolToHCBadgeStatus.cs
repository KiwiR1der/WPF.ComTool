using HandyControl.Data;
using System.Globalization;
using System.Windows.Data;

namespace WPF.ComTool.Converters
{
    public class BoolToHCBadgeStatus : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out bool result))
            {
                return result ? BadgeStatus.Processing : BadgeStatus.Dot;
            }
            return BadgeStatus.Dot;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
