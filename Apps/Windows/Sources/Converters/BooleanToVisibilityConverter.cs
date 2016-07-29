using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VideoManager.Sources.Converters
{
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return bool.Parse(value.ToString()) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return bool.Parse(value.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }

    }
}
