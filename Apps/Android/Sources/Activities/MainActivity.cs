using System;
using Android.App;
using Android.Content.PM;
using Android.Support.V7.Widget;
using Core.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using VideoManager.Sources.Adapters;

namespace VideoManager.Droid.Sources.Activities
{
    [Activity(
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.FullSensor,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public partial class MainActivity
    {

        #region Properties

        private MainViewModel viewModel => App.Locator.MainViewModel;

        private VideoListAdapter adapter;

        #endregion

        #region Override Methods

        protected override void InitializeData()
        {
            viewModel.LoadData();

            var layoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            RecyclerView.SetLayoutManager(layoutManager);

            RecyclerView.HasFixedSize = true;
            RecyclerView.SetItemAnimator(new DefaultItemAnimator());

            adapter = new VideoListAdapter(this);
            RecyclerView.SetAdapter(adapter);

            SetColorScheme(
                Resource.Color.color_scheme_1,
                Resource.Color.color_scheme_2,
                Resource.Color.color_scheme_3,
                Resource.Color.color_scheme_4);

            SwipeRefreshLayout.Refresh += RereshDataEvent;
        }

        protected override void InitializeBinding()
        {
            Bindings.Add(this.SetBinding(
                                () => viewModel.IsLoading,
                                () => SwipeRefreshLayout.Refreshing));
            Bindings.Add(this.SetBinding(
                                () => viewModel.Videos)
                             .WhenSourceChanges(adapter.NotifyDataSetChanged));
        }

        protected override void ConfigureActionBar()
        {
            SetNavigationBackIcon(Resource.Drawable.selector_button_back);
            Title = GetString(Resource.String.app_name);
        }

        #endregion

        #region Lifecycle

        protected override void OnDestroy()
        {
            base.OnDestroy();

            viewModel.UnLoadData();
        }

        #endregion

        #region Private Methods

        private void SetColorScheme(int colorRes1, int colorRes2, int colorRes3, int colorRes4)
        {
            SwipeRefreshLayout.SetColorSchemeResources(colorRes1, colorRes2, colorRes3, colorRes4);
        }

        #endregion

        #region Actions

        private void RereshDataEvent(object sender, EventArgs e)
        {
            viewModel.RefreshCommand
                     .Execute(null);
        }

        #endregion

    }
}