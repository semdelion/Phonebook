using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using Phonebook.Core.ViewModels;
using UIKit;

namespace Phonebook.iOS.Views
{
    public partial class ContactRow : MvxTableViewCell

    {
        public static readonly NSString Key = new NSString("ContactRow");
        public static readonly UINib Nib;

        static ContactRow()
        {
            Nib = UINib.FromName("ContactRow", NSBundle.MainBundle);
        }

        protected ContactRow(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ContactRow, Items>();
                set.Bind(Title).To(vm => vm.FullName);
                set.Bind(Image).For(i => i.ImagePath).To(vm => vm.Photo);
                set.Apply();
            });
        }
    }
}


   

