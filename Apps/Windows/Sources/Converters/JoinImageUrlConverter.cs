using System;
using Windows.UI.Xaml.Data;

namespace VideoManager.Sources.Converters
{
    public sealed class JoinImageUrlConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return $"https://commondatastorage.googleapis.com/gtv-videos-bucket/CastVideos/images/{value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return $"";
        }

    }
}
