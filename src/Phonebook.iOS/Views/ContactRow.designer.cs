// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Phonebook.iOS.Views
{
    [Register ("ContactRow")]
    partial class ContactRow
    {
        [Outlet]
        FFImageLoading.Cross.MvxCachedImageView Image { get; set; }

        [Outlet]
        UIKit.UILabel Title { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }

            if (Title != null)
            {
                Title.Dispose();
                Title = null;
            }
        }
        
    }
}