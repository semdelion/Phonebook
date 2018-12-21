using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Phonebook.iOS.Views
{
    [Register("ContactsCell")]
    partial class ContactsCell
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        FFImageLoading.Cross.MvxCachedImageView Image { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
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