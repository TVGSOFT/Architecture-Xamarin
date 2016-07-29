using Core.Constants;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using VideoManager.Droid.Sources.Activities;

namespace VideoManager.Droid.Sources.ViewModel
{
    public sealed class ViewModelLocator : Core.ViewModel.ViewModelLocator
    {

        #region Constructors
        
        public ViewModelLocator() : base()
        {

        }

        #endregion

        #region Override Methods

        protected override void RegisterView()
        {
            var navigationService = new AppNavigationService();
            navigationService.Configure(Constant.ViewKey.MainView, typeof(MainActivity));
            navigationService.Configure(Constant.ViewKey.VideoDetailView, typeof(VideoDetailActivity));
            navigationService.Configure(Constant.ViewKey.PlayVideoView, typeof(PlayVideoActivity));

            SimpleIoc.Default.Register<Core.ViewModel.INavigationService>(() => navigationService);

            SimpleIoc.Default.Register<IDialogService, AppDialogService>();
        }

        #endregion

    }
}