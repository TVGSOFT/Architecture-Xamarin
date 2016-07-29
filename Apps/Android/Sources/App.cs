using Android.App;
using Android.Content;
using Android.Net;
using Android.Runtime;
using Android.Widget;
using Core.ViewModel;
using Network;
using System;
using static Network.NetworkStatusReceiver;

namespace VideoManager.Droid.Sources
{
    [Application(
        LargeHeap = true,
        Label = "@string/app_name",
        Icon = "@mipmap/icon",
        Theme = "@style/AppTheme.NoActionBar")]
    public class App : Application
    {

        #region Properties

        public static Application Default { get; private set; }

        public static ViewModelLocator Locator { get; private set; }

        private NetworkStatusReceiver networkReceiver;

        #endregion

        #region Constructors

        protected App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        #endregion

        #region Deconstructors

        ~App()
        {
            networkReceiver.StatusChanged -= NetworkStatusChanged;
            UnregisterReceiver(networkReceiver);
        }

        #endregion

        #region Lifecycle

        public override void OnCreate()
        {
            base.OnCreate();

            Locator = new ViewModel.ViewModelLocator();

            Default = this;

            RegisterNetworkStatus();
        }

        #endregion

        #region Private Methods

        private void RegisterNetworkStatus()
        {
            networkReceiver = new NetworkStatusReceiver();
            networkReceiver.StatusChanged += NetworkStatusChanged;

            var intentFilter = new IntentFilter(ConnectivityManager.ConnectivityAction);

            RegisterReceiver(networkReceiver, intentFilter);
        }

        #endregion

        #region Actions

        private void NetworkStatusChanged(object sender, NetworkStatusEventArgs e)
        {
            Toast.MakeText(ApplicationContext, e.Message, ToastLength.Long)
                 .Show();
        }

        #endregion

    }
}