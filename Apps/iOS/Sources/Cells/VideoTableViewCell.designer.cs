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

namespace VideoManager.iOS.Sources.Cells
{
    [Register ("VideoTableViewCell")]
    partial class VideoTableViewCell
    {
        [Outlet]
        UIKit.UIButton buttonPlay { get; set; }


        [Outlet]
        UIKit.UIImageView imageViewThumbnail { get; set; }


        [Outlet]
        UIKit.UILabel labelDescription { get; set; }


        [Outlet]
        UIKit.UILabel labelTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (buttonPlay != null) {
                buttonPlay.Dispose ();
                buttonPlay = null;
            }

            if (imageViewThumbnail != null) {
                imageViewThumbnail.Dispose ();
                imageViewThumbnail = null;
            }

            if (labelDescription != null) {
                labelDescription.Dispose ();
                labelDescription = null;
            }

            if (labelTitle != null) {
                labelTitle.Dispose ();
                labelTitle = null;
            }
        }
    }
}