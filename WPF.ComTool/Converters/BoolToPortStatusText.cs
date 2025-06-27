using System.Globalization;
using System.Windows.Data;

namespace WPF.ComTool.Converters
{
    public class BoolToPortStatusText : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out bool result))
            {
                return result ? "关闭串口" : "打开串口";
            }
            return "未知状态";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
