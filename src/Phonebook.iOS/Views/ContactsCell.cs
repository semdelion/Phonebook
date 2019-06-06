using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using Phonebook.Core.ViewModels;
using UIKit;

namespace Phonebook.iOS.Views
{
    public partial class ContactsCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("ContactsCell");
        public static readonly UINib Nib;

        static ContactsCell()
        {
            Nib = UINib.FromName("ContactsCell", NSBundle.MainBundle);
        }

        protected ContactsCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ContactsCell, ItemContact>();
                set.Bind(Title).To(vm => vm.FullName);
                set.Bind(Image).For(i => i.ImagePath).To(vm => vm.Photo);
                set.Apply();
            });
        }
    }
}


   

