using System;
using System.Windows.Input;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Phonebook.iOS.Views
{
    public class ContactsTableSource : MvxSimpleTableViewSource
    {
        public ICommand PagingCommand { get; set; }

        public ContactsTableSource(IntPtr handle)
            : base(handle)
        {
        }

        public ContactsTableSource(UITableView tableView, string nibName, string cellIdentifier = null, NSBundle bundle = null)
            : base(tableView, nibName, cellIdentifier, bundle)
        {
        }

        public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            if (indexPath.Row >= RowsInSection(tableView, indexPath.Section) - 3 &&
               (PagingCommand?.CanExecute(null) ?? false))
            {
                PagingCommand.Execute(null);
            }
        }
    }
}
