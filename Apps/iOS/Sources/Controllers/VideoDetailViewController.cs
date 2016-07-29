using UIKit;
using Core.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using System;
using VideoManager.iOS.Sources.Controllers.Abstracts;
using Foundation;
using SDWebImage;
using Components;

namespace VideoManager.iOS.Sources.Controllers
{
	public partial class VideoDetailViewController : ViewController<VideoDetailViewModel>
	{

		#region Properties

		protected override VideoDetailViewModel ViewModel => AppDelegate.App
		                                                                .Locator
		                                                                .VideoDetailViewModel;

		#endregion

		#region Constructors

		protected VideoDetailViewController(IntPtr handle) : base(handle)
		{
		}

		#endregion

		#region Lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Bindings.Add(this.SetBinding(
								() => ViewModel.VideoDetail)
						 	 .WhenSourceChanges(VideoDataChanged));

			buttonPlay.SetCommand("TouchUpInside", ViewModel.PlayCommand);
		}
	
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

		#endregion

		#region Binding Methods

		private void VideoDataChanged()
		{
			if (ViewModel.VideoDetail != null)
			{
				imageViewThumb.SetImage(new NSUrl($"{ViewModel.ThumbnailUrl}"));

				labelTitle.Text = $"{ViewModel.VideoDetail.Video.Title} - {ViewModel.VideoDetail.Video.Studio}";
				labelSubtitle.Text = ViewModel.VideoDetail.Video.Subtitle;
			}
		}

		#endregion

	}
}


