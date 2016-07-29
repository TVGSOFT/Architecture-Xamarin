using Android.Content;
using Android.Net;
using Android.Runtime;

namespace Network
{
    public class NetworkStatusHelper
    {

        #region Constructors

        private NetworkStatusHelper()
        {

        }

        #endregion

        #region Static Methods

        public static NetworkInfo GetNetworkInfo(Context context)
        {
            var connectManager = context.GetSystemService(Context.ConnectivityService)
                                        .JavaCast<ConnectivityManager>();
            return connectManager.ActiveNetworkInfo;
        }

        public static string GetNetworkStatus(Context context)
        {
            var networkInfo = GetNetworkInfo(context);
          
            if (networkInfo != null)
            {
                return $"{networkInfo.TypeName} connected {networkInfo.ExtraInfo}";
            }

            return "No internet connection.";
        }

        #endregion

    }
}