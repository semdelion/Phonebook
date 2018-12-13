
using System;
using System.Drawing;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using Phonebook.Core.ViewModels;
using UIKit;

namespace Phonebook.iOS.Views
{
    public partial class ContactsView : MvxViewController<ContactsViewModel>
    {
        private MvxUIRefreshControl _refreshControl;

        public ContactsView(): base(nameof(ContactsView), null)
        {
        }

        private void AddRefresh()
        {
            _refreshControl = new MvxUIRefreshControl();
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                TableView.RefreshControl = _refreshControl;
            }
            else
            {
                TableView.Add(_refreshControl);
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = "Phonebook";


            AddRefresh();
            var source = new MvxSimpleTableViewSource(TableView, ContactsCell.Key, ContactsCell.Key);
            TableView.RowHeight = 80;

            var set = this.CreateBindingSet<ContactsView, ContactsViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Apply();

            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}
