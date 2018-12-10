using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;

namespace Phonebook.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class ContactsView : MvxViewController
    {
        public ContactsView() : base("ContactsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<ContactsView, Core.ViewModels.ContactsViewModel>();
                set.Bind(Label).To(vm => vm.Text);
                set.Bind(Button).To(vm => vm.ResetTextCommand);
                set.Apply();
        }
    }
}