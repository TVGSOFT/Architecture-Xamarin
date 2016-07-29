// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Components
{
	[Register ("LoadingView")]
	partial class LoadingView
	{
		[Outlet]
		UIKit.UILabel labelMessage { get; set; }

		[Outlet]
		UIKit.UIView viewIndicator { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (viewIndicator != null) {
				viewIndicator.Dispose ();
				viewIndicator = null;
			}

			if (labelMessage != null) {
				labelMessage.Dispose ();
				labelMessage = null;
			}
		}
	}
}
