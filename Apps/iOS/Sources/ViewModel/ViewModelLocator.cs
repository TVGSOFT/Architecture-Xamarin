using Core.Constants;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using VideoManager.iOS.Sources.Controllers;

namespace VideoManager.iOS.Sources.ViewModel
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
			navigationService.Configure(Constant.ViewKey.MainView, nameof(MainViewController));
			navigationService.Configure(Constant.ViewKey.VideoDetailView, nameof(VideoDetailViewController));
			navigationService.Configure(Constant.ViewKey.PlayVideoView, nameof(PlayVideoViewController));

			SimpleIoc.Default.Register<Core.ViewModel.INavigationService>(() => navigationService);
			SimpleIoc.Default.Register<IDialogService, DialogService>();
		}

		#endregion

	}
}