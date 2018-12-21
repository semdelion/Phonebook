using System;
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

        public ContactsView() : base(nameof(ContactsView), null)
        {
        }

        private void AddRefresh()
        {
            _refreshControl = new MvxUIRefreshControl();
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                tableView.RefreshControl = _refreshControl;
            }
            else
            {
                tableView.Add(_refreshControl);
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = "Phonebook";

            AddRefresh();
            var source = new ContactsTableSource(tableView, ContactsCell.Key);

            tableView.RowHeight = 80;

            var set = this.CreateBindingSet<ContactsView, ContactsViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);
            set.Bind(_refreshControl).For(s => s.IsRefreshing).To(vm => vm.IsRefreshing);
            set.Bind(source).For(s => s.PagingCommand).To(vm => vm.GettingContactsCommand);
            set.Bind(_refreshControl).For(s => s.RefreshCommand).To(vm => vm.RefreshContactsCommand);
            set.Apply();

            tableView.Source = source;
            tableView.ReloadData();
        }
    }
}

