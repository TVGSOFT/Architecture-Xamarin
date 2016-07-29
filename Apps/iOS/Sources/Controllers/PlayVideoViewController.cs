using System;
using Core.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using VideoManager.iOS.Sources.Controllers.Abstracts;
using AVFoundation;
using Foundation;

namespace VideoManager.iOS.Sources.Controllers
{
	public partial class PlayVideoViewController : PlayerViewController<PlayVideoViewModel>
	{

		#region Properties

		protected override PlayVideoViewModel ViewModel => AppDelegate.App
																	  .Locator
																	  .PlayVideoViewModel;

		#endregion

		#region Constructors

		public PlayVideoViewController(IntPtr handle) : base(handle)
		{
		}

		#endregion

		#region Lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Bindings.Add(this.SetBinding(
								() => ViewModel.VideoUrl)
						  	 .WhenSourceChanges(VideoDataChanged));
		}

		#endregion

		#region Binding Methods

		private void VideoDataChanged()
		{
			if (ViewModel.VideoUrl != null)
			{
				var player = new AVPlayer(new NSUrl(ViewModel.VideoUrl));
				Player = player;
				Player.Play();
			}
		}

		#endregion

	}
}


