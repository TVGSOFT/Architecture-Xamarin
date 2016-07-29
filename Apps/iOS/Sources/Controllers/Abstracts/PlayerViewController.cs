using UIKit;
using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using Core.Abstracts.ViewModel;
using VideoManager.iOS.Sources.ViewModel;
using AVKit;

namespace VideoManager.iOS.Sources.Controllers.Abstracts
{
	public abstract class PlayerViewController<V> : AVPlayerViewController where V : AbstractViewModel
	{

		#region Properties

		protected abstract V ViewModel { get; }

		private List<Binding> bindings;
		protected List<Binding> Bindings => bindings ?? (bindings = new List<Binding>());

		protected AppNavigationService NavigationService => AppDelegate.App.Locator.NavigationService as AppNavigationService;

		#endregion

		#region Constructors

		protected PlayerViewController(IntPtr handle) : base(handle)
		{
		}

		#endregion

		#region Lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			ViewModel?.LoadData();

			Title = ViewModel?.Title;
		}

		#endregion

		#region Override Methods

		public override void DidMoveToParentViewController(UIViewController parent)
		{
			base.DidMoveToParentViewController(parent);

			if (parent == null)
			{
				OnDestroy();
			}
		}

		#endregion

		#region Protected Methods

		protected virtual void OnDestroy()
		{
			if (bindings != null)
			{
				foreach (var binding in Bindings)
				{
					binding.Detach();
				}
				bindings = null;
			}

			ViewModel?.UnLoadData();
		}

		#endregion

	}
}




