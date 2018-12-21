using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using Phonebook.Core.ViewModels.Details;
using MvvmCross.Platforms.Ios.Binding;
using UIKit;

namespace Phonebook.iOS.Views.Details
{
    public partial class ContactDetailsViewController : MvxViewController<DetailsViewModel>
    {
        public ContactDetailsViewController() : base("ContactDetailsViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ContactDetailsViewController, DetailsViewModel>();
            set.Bind(Photo).For(v => v.ImagePath).To(vm => vm.CurrentContact.Photo);
            set.Bind(Photo).For(v => v.BindTap()).To(vm=>vm.PhotoClick);
            set.Bind(FullName).To(vm => vm.CurrentContact.FullName);
            set.Bind(Phone).To(vm => vm.CurrentContact.Phone);
            set.Bind(Mail).To(vm => vm.CurrentContact.Mail);
            set.Apply();
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;
            }
        }
    }
}


