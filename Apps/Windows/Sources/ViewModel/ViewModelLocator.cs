using Core.Constants;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using VideoManager.Sources.Pages;

namespace VideoManager.Sources.ViewModel
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
            navigationService.Configure(Constant.ViewKey.MainView, typeof(MainPage));
            navigationService.Configure(Constant.ViewKey.VideoDetailView, typeof(VideoDetailPage));
            navigationService.Configure(Constant.ViewKey.PlayVideoView, typeof(PlayVideoPage));

            SimpleIoc.Default.Register<Core.ViewModel.INavigationService>(() => navigationService);

            SimpleIoc.Default.Register<IDialogService, DialogService>();
        }

        #endregion

    }
}