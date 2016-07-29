using Android.App;
using Android.Content;
using Android.Net;
using System;

namespace Network
{
    [BroadcastReceiver]
    [IntentFilter(new[] { ConnectivityManager.ConnectivityAction })]
    public class NetworkStatusReceiver : BroadcastReceiver
    {

        public EventHandler<NetworkStatusEventArgs> StatusChanged;

        public override void OnReceive(Context context, Intent intent)
        {
            var action = intent?.Action;
            if (action == ConnectivityManager.ConnectivityAction)
            {
                var message = NetworkStatusHelper.GetNetworkStatus(context);

                var status = new NetworkStatusEventArgs(message);
                StatusChanged?.Invoke(this, status);
            }
        }

        #region NetworkStatusEventArgs

        public class NetworkStatusEventArgs : EventArgs
        {

            #region Properties

            public string Message { get; private set; }

            #endregion

            #region Constructors

            public NetworkStatusEventArgs(string message) : base()
            {
                Message = message;
            }

            #endregion

        }

        #endregion

    }
}