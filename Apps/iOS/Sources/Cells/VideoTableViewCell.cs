using System;
using Core.Model.Entities;
using UIKit;
using SDWebImage;
using Foundation;
using Core.ViewModel;

namespace VideoManager.iOS.Sources.Cells
{
	public partial class VideoTableViewCell : UITableViewCell
	{

		#region Properties

		private MainViewModel viewModel => AppDelegate.App.Locator.MainViewModel;

		private Video video;

		#endregion

		#region Constructors

		protected VideoTableViewCell(IntPtr handle) : base(handle)
		{
		}

		#endregion

		#region Override Methods

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			buttonPlay.TouchUpInside -= ButtonPlayClicked;
			buttonPlay.TouchUpInside += ButtonPlayClicked;
		}
	
		#endregion

		#region Public Methods

		public void UpdateData(String images, Video video)
		{
			this.video = video;

			imageViewThumbnail.SetImage(new NSUrl($"{images}{video.Thumb}"));
			labelTitle.Text = video.Title;
			labelDescription.Text = video.Studio;
		}

		#endregion

		#region Actions

		private void ButtonPlayClicked(object sender, EventArgs e)
		{
			viewModel.PlayCommand.Execute(video);
		}

		#endregion

	}
}
