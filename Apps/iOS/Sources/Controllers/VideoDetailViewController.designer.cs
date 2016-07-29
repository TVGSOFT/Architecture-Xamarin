// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace VideoManager.iOS.Sources.Controllers
{
    [Register ("VideoDetailViewController")]
    partial class VideoDetailViewController
    {
        [Outlet]
        UIKit.UIButton buttonPlay { get; set; }


        [Outlet]
        UIKit.UIImageView imageViewThumb { get; set; }


        [Outlet]
        UIKit.UILabel labelSubtitle { get; set; }


        [Outlet]
        UIKit.UILabel labelTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (buttonPlay != null) {
                buttonPlay.Dispose ();
                buttonPlay = null;
            }

            if (imageViewThumb != null) {
                imageViewThumb.Dispose ();
                imageViewThumb = null;
            }

            if (labelSubtitle != null) {
                labelSubtitle.Dispose ();
                labelSubtitle = null;
            }

            if (labelTitle != null) {
                labelTitle.Dispose ();
                labelTitle = null;
            }
        }
    }
}