using UIKit;
using Core.ViewModel;
using System;
using System.Linq;
using VideoManager.iOS.Sources.Cells;
using GalaSoft.MvvmLight.Helpers;
using VideoManager.iOS.Sources.Controllers.Abstracts;
using Components;

namespace VideoManager.iOS.Sources.Controllers
{
	public partial class MainViewController : TableViewController<MainViewModel>
	{

		#region Properties

		protected override MainViewModel ViewModel => AppDelegate.App
		                                                         .Locator
		                                                         .MainViewModel;

		private UIRefreshControl refreshControl;

		#endregion

		#region Constructors

		protected MainViewController(IntPtr handle) : base(handle)
		{
		}

		#endregion

		#region Lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			refreshControl = new UIRefreshControl();
			TableView.AddSubview(refreshControl);
			refreshControl.ValueChanged += (sender, e) => ViewModel.RefreshCommand.Execute(null);

			Bindings.Add(this.SetBinding(
								() => ViewModel.Videos)
						 	 .WhenSourceChanges(
				             	() => TableView.ReloadData()));
			Bindings.Add(this.SetBinding(
								() => ViewModel.IsLoading)
			             	 .WhenSourceChanges(EndRefreshing));
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}
	
		#endregion

		#region Override Methods

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return ViewModel.Videos?.Count() ?? 0;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var video = ViewModel.Videos
			                     .ElementAtOrDefault(indexPath.Row);

			var cell = tableView.DequeueReusableCell("VideoTableViewCell", indexPath) as VideoTableViewCell;
			cell.UpdateData(ViewModel.Category.Images, video);

			return cell;
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var video = ViewModel.Videos
			                     .ElementAtOrDefault(indexPath.Row);

			ViewModel.SelectedVideo = video;
		}

		#endregion

		#region Binding Methods

		private void EndRefreshing()
		{
			if (ViewModel.IsLoading)
			{
				if (!refreshControl.Refreshing)
				{
					refreshControl.BeginRefreshing();
				}
			}
			else
			{
				refreshControl.EndRefreshing();
			}
		}

		#endregion

	}
}


