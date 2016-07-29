using System;
using Windows.UI.Xaml.Data;

namespace VideoManager.Sources.Converters
{
    public sealed class StringToUriConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var url = value as string;
                return new Uri(url ?? "");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return $"";
        }

    }
}
