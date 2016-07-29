using Android.App;
using Android.Content.PM;
using Core.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using Square.Picasso;

namespace VideoManager.Droid.Sources.Activities
{
    [Activity(
       ScreenOrientation = ScreenOrientation.FullSensor,
       ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public partial class VideoDetailActivity
    {

        #region Properties

        private VideoDetailViewModel viewModel => App.Locator.VideoDetailViewModel;

        #endregion

        #region Override Methods

        protected override void InitializeData()
        {
            viewModel.LoadData();
        }

        protected override void InitializeBinding()
        {
            Bindings.Add(this.SetBinding(
                                () => viewModel.VideoDetail)
                             .WhenSourceChanges(VideoDataChanged));

            ImageButtonPlay.SetCommand("Click", viewModel.PlayCommand);
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
            Picasso.With(this)
                   .Load(viewModel.ThumbnailUrl)
                   .Into(ImageView);

            TextViewTitle.Text = $"{viewModel.VideoDetail.Video.Title} - {viewModel.VideoDetail.Video.Studio}";
            TextViewSubTitle.Text = viewModel.VideoDetail.Video.Subtitle;
        }

        #endregion

    }
}