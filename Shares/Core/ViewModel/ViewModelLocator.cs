using Core.Model.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics.CodeAnalysis;
using Core.Constants;

namespace Core.ViewModel
{
    public abstract class ViewModelLocator
    {

        [SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        #region Properties

        public INavigationService NavigationService => ServiceLocator.Current.GetInstance<INavigationService>();

        public IVideoCloudService CloudService => ServiceLocator.Current.GetInstance<IVideoCloudService>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public VideoDetailViewModel VideoDetailViewModel => ServiceLocator.Current.GetInstance<VideoDetailViewModel>();

        public PlayVideoViewModel PlayVideoViewModel => ServiceLocator.Current.GetInstance<PlayVideoViewModel>();

        #endregion

        #region Constructors

		protected ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterServices();

            RegisterView();

            RegisterViewModel();
        }

        #endregion

        #region Register Methods

        private void RegisterServices()
        {
			var cloudManager = new CloudManager(Constant.Url.Server);
			SimpleIoc.Default.Register(() => cloudManager);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IVideoCloudService, DesignVideoCloudService>();
            }
            else
            {
                SimpleIoc.Default.Register<IVideoCloudService, VideoCloudService>();
            }
        }

        private void RegisterViewModel()
        {
            SimpleIoc.Default.Register<MainViewModel>(true);
            SimpleIoc.Default.Register<VideoDetailViewModel>(true);
            SimpleIoc.Default.Register<PlayVideoViewModel>(true);
        }

        protected abstract void RegisterView();

        #endregion
        
    }
}
