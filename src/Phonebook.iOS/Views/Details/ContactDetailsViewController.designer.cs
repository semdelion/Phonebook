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

namespace Phonebook.iOS.Views.Details
{
    [Register ("ContactDetailsViewController")]
    partial class ContactDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FullName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Mail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Phone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        FFImageLoading.Cross.MvxCachedImageView Photo { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FullName != null) {
                FullName.Dispose ();
                FullName = null;
            }

            if (Mail != null) {
                Mail.Dispose ();
                Mail = null;
            }

            if (Phone != null) {
                Phone.Dispose ();
                Phone = null;
            }

            if (Photo != null) {
                Photo.Dispose ();
                Photo = null;
            }
        }
    }
}