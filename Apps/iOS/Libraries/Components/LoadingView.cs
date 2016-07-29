using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Components
{
	public partial class LoadingView : UIView
	{

		#region Properties

		public string Title
		{
			get
			{
				return labelMessage.Text;
			}
			set
			{
				labelMessage.Text = value;
			}
		}

		#endregion

		#region Constructors 

		protected LoadingView(IntPtr handle) 
			: base(handle)
		{ 
		}

		protected LoadingView(NSObjectFlag t) 
			: base(t)
		{ 
		}

		public LoadingView()
		{ 
		}
		
		public LoadingView(CGRect frame) 
			: base(frame)
		{ 
			Initialize();
		}

		public LoadingView(NSCoder coder) 
			: base(coder)
		{ 
			Initialize();
		}

		#endregion

		#region Override Methods 

		public override void AwakeFromNib()
		{ 
			base.AwakeFromNib();
			Initialize();
		}

		#endregion

		#region Public Methods

		public static LoadingView Create()
		{
			var nibs = NSBundle.MainBundle.LoadNib(nameof(LoadingView), null, null);
			return Runtime.GetNSObject<LoadingView>(nibs.ValueAt(0));
		}

		#endregion

		#region Private Methods 

		private void Initialize() 
		{
			viewIndicator.Layer.CornerRadius = viewIndicator.Frame.Width / 2.0f;
			viewIndicator.Layer.BorderWidth = 3.0f;
			viewIndicator.Layer.BorderColor = UIColor.White.CGColor;

			labelMessage.Layer.CornerRadius = 5;
		}

		#endregion

	}
}