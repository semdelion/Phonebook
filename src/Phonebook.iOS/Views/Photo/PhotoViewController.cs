using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using Phonebook.Core.ViewModels.Photo;
using UIKit;

namespace Phonebook.iOS.Views.Photo
{
    public partial class PhotoViewController : MvxViewController<PhotoViewModel>
    {
        public PhotoViewController() : base("PhotoViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<PhotoViewController, PhotoViewModel>();
            set.Bind(Photo).For(v => v.ImagePath).To(vm=>vm.Photo);
            set.Apply();
            // Perform any additional setup after loading the view, typically from a nib.
        }

       
    }
}

