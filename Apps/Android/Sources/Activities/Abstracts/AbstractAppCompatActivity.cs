using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Core.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;

namespace VideoManager.Droid.Sources.Activities.Abstracts
{
    public abstract class AbstractAppCompatActivity : AppCompatActivity
    {

        #region Properties

        protected Toolbar Toolbar;

        protected INavigationService NavigationService => App.Locator.NavigationService;
        protected IMessenger MessengerInstance => GalaSoft.MvvmLight.Messaging.Messenger.Default;

        private List<Binding> bindings;
        protected List<Binding> Bindings => bindings ?? (bindings = new List<Binding>());

        public static AbstractAppCompatActivity CurrentActivity;

        public string ActivityKey { get; private set; }

        public static string NextPageKey { get; set; }

        #endregion

        #region Lifecycle

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            InitializeUI();

            InitializeData();

            InitializeBinding();

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
            }

            ConfigureActionBar();
        }

        protected override void OnResume()
        {
            CurrentActivity = this;

            if (string.IsNullOrEmpty(ActivityKey))
            {
                ActivityKey = NextPageKey;
                NextPageKey = null;
            }

            base.OnResume();
        }

        protected override void OnDestroy()
        {
            foreach (var binding in Bindings)
            {
                binding.Detach();
            }
            bindings = null;

            base.OnDestroy();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                OnBackPressed();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        #endregion

        #region Abstract Methods

        protected abstract void InitializeUI();

        protected abstract void InitializeData();

        protected abstract void InitializeBinding();

        protected abstract void ConfigureActionBar();

        #endregion

        #region Protected Methods

        protected void SetNavigationBackgroundColor(int colorId)
        {
            Toolbar?.SetBackgroundResource(colorId);
        }

        protected void SetNavigationBackIcon(int resourceId)
        {
            Toolbar?.SetNavigationIcon(resourceId);
        }

        protected void ScaleSizeForDialog(float x, float y)
        {
            ScaleSizeForDialog((int)(Resources.DisplayMetrics.WidthPixels * x), (int)(Resources.DisplayMetrics.HeightPixels * y));
        }

        protected void ScaleSizeForDialog(int width, int height)
        {
            Window.Attributes.Width = width;
            Window.Attributes.Height = height;
        }

        #endregion

        #region Static Methods

        public static void GoBack() => CurrentActivity?.OnBackPressed();

        #endregion

    }
}