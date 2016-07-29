using Android.App;
using Android.Content.PM;
using GalaSoft.MvvmLight.Helpers;
using Core.ViewModel;
using Android.Net;
using Android.Widget;

namespace VideoManager.Droid.Sources.Activities
{

    [Activity(
       ScreenOrientation = ScreenOrientation.FullSensor,
       ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public partial class PlayVideoActivity
    {

        #region Properties

        private PlayVideoViewModel viewModel => App.Locator.PlayVideoViewModel;

        #endregion

        #region Override Methods

        protected override void InitializeData()
        {
            viewModel.LoadData();

            var mediaController = new MediaController(this);
            VideoView.SetMediaController(mediaController);
        }

        protected override void InitializeBinding()
        {
            Bindings.Add(this.SetBinding(
                                () => viewModel.VideoDetail)
                             .WhenSourceChanges(VideoDataChanged));
        }

        protected override void ConfigureActionBar()
        {
            SetNavigationBackIcon(Resource.Drawable.selector_button_back);
            Title = viewModel.VideoDetail.Video.Title;
        }

        #endregion

        #region Lifecycle

        protected override void OnDestroy()
        {
            base.OnDestroy();

            viewModel.UnLoadData();
        }

        #endregion

        #region Binding Methods

        private void VideoDataChanged()
        {
            VideoView.SetVideoURI(Uri.Parse(viewModel.VideoUrl));
            VideoView.RequestFocus();
            VideoView.Start();
        }

        #endregion

    }
}