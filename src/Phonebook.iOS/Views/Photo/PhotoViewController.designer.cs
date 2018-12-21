// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Phonebook.iOS.Views.Photo
{
    [Register ("PhotoViewController")]
    partial class PhotoViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        FFImageLoading.Cross.MvxCachedImageView Photo { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Photo != null) {
                Photo.Dispose ();
                Photo = null;
            }
        }
    }
}