using System;
using Core.ViewModel;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace VideoManager.iOS.Sources.ViewModel
{
	public class AppNavigationService : INavigationService
	{

		#region Properties

		public UINavigationController NavigationController
		{
			get;
			private set;
		}

		public const string RootPageKey = "-- ROOT --";

		public const string UnknownPageKey = "-- UNKNOWN --";

		private Dictionary<string, string> pagesByKey = new Dictionary<string, string>();

		#endregion

		#region Public Methods

		public void Initialize(UINavigationController navigationController)
		{
			NavigationController = navigationController;
		}

		public void Configure(string key, string storyboardId)
		{
			SaveConfigurationItem(key, storyboardId);
		}

		#endregion

		#region Private Methods

		private void SaveConfigurationItem(string key, string storyboardId)
		{
			lock (pagesByKey)
			{
				if (pagesByKey.ContainsKey(key))
				{
					pagesByKey[key] = storyboardId;
				}
				else
				{
					pagesByKey.Add(key, storyboardId);
				}
			}
		}

		#endregion

		#region Implement INavigationService

		/// <summary>
		/// Gets the current page key.
		/// </summary>
		/// <value>The current page key.</value>
		public string CurrentPageKey
		{
			get
			{
				lock (pagesByKey)
				{
					if (NavigationController.ViewControllers.Length == 0)
					{
						return RootPageKey;
					}

					var topController = NavigationController.TopViewController;

					var item = pagesByKey.Values
					                     .FirstOrDefault(storyboardId => storyboardId == nameof(topController));

					if (item == null)
					{
						return UnknownPageKey;
					}

					var pair = pagesByKey.FirstOrDefault(i => i.Value == item);
					return pair.Key;
				}
			}
		}

		/// <summary>
		/// Begins the invoke on user interface.
		/// </summary>
		/// <returns>The invoke on user interface.</returns>
		/// <param name="action">Action.</param>
		public void BeginInvokeOnUI(Action action)
		{
			NavigationController?.BeginInvokeOnMainThread(action);
		}

		/// <summary>
		/// Gos the back.
		/// </summary>
		/// <returns>The back.</returns>
		public void GoBack()
		{
			NavigationController?.PopViewController(true);
		}

		/// <summary>
		/// Navigates to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="pageKey">Page key.</param>
		public void NavigateTo(string pageKey)
		{
			NavigateTo(pageKey, null);
		}

		/// <summary>
		/// Navigates to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="pageKey">Page key.</param>
		/// <param name="parameter">Parameter.</param>
		public void NavigateTo(string pageKey, object parameter)
		{
			if (!pagesByKey.ContainsKey(pageKey))
			{
				throw new ArgumentNullException(pageKey, "This method must be called with a valid UIViewController"); 
			}

			var topViewController = NavigationController.TopViewController;
			
			if (parameter is NSObject)
			{
				topViewController?.PerformSegue(pageKey, parameter as NSObject);
			}
			else
			{
				topViewController?.PerformSegue(pageKey, null);
			}
		}

		#endregion

	}
}

