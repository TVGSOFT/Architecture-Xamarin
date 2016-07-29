using UIKit;

namespace Components
{
	public static class LoadingManager
	{

		/// <summary>
		/// Show the specified view.
		/// </summary>
		/// <param name="view">View.</param>
		public static void Show(UIView view, bool interaction = true)
		{
			if (!interaction)
			{
				UIApplication.SharedApplication.BeginIgnoringInteractionEvents();
			}

			Hide(view);

			var loadingView = LoadingView.Create();
			loadingView.Frame = view.Bounds;

			view.AddSubview(loadingView);
		}

		/// <summary>
		/// Hide the specified view.
		/// </summary>
		/// <param name="view">View.</param>
		public static void Hide(UIView view)
		{
			foreach (var subview in view.Subviews)
			{
				if (subview is LoadingView)
				{
					subview.RemoveFromSuperview();
				}
			}

			UIApplication.SharedApplication.EndIgnoringInteractionEvents();
		}

	}
}

