using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API.Service;
using System;
using System.Threading.Tasks;

namespace Phonebook.Core.ViewModels
{
    public class ContactsViewModel : MvxViewModel
    {
        private MvxObservableCollection<Items> _items;
        private bool _isRefreshing;
      
        readonly IContactService _contactService;
        readonly IMvxNavigationService _navigationService;
        private IMvxCommand _refreshContactsCommand;
        

        public MvxObservableCollection<Items> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }


        public IMvxCommand RefreshContactsCommand => _refreshContactsCommand ?? (_refreshContactsCommand = new MvxAsyncCommand(PullToRefresh));
        public ContactsViewModel(IMvxNavigationService navigationService, IContactService contactService)
        {
            _navigationService = navigationService;
            _contactService = contactService;
            _items = new MvxObservableCollection<Items>();
        }

        private async Task GetContacts()
        {
            var contacts = await _contactService.GetContacts(SettingsConstants.CountOfContacts, SettingsConstants.CountOfPage).ConfigureAwait(false);
            foreach (var cont in contacts.Contacts)
                Items.Add(new ViewModels.Items(cont));
        }

        private async Task PullToRefresh()
        {
            IsRefreshing = true;
            Items.Clear();
            await GetContacts();
            IsRefreshing = false;
        }

        public override void ViewAppeared()
        {
            if (_items == null)
                Task.Run(GetContacts);
            base.ViewAppeared();
        }
    }
}