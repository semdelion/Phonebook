using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.ViewModels
{
    public class ContactsViewModel : MvxViewModel
    {
        private int page = 1;
        private MvxObservableCollection<ItemContact> _items;
        private bool _isRefreshing;
      
        readonly IContactService _contactService;
        readonly IMvxNavigationService _navigationService;
        readonly IMessage _message;

        private IMvxCommand _refreshContactsCommand;
        private IMvxCommand _gettingCommand;

        public MvxObservableCollection<ItemContact> Items
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
        public IMvxCommand GettingContactsCommand => _gettingCommand ?? (_gettingCommand = new MvxAsyncCommand(GetContacts));
        public ContactsViewModel(IMvxNavigationService navigationService, IContactService contactService, IMessage message)
        {
            _navigationService = navigationService;
            _contactService = contactService;
            _message = message;
            _items = new MvxObservableCollection<ItemContact>();
        }

        private async Task GetContacts()
        {
            try
            {
                var contacts = await _contactService.GetContacts(SettingsConstants.CountOfContacts, page).ConfigureAwait(false);
                if (contacts != null && contacts.Contacts.Count == SettingsConstants.CountOfContacts)
                {
                    page++;
                    var tmp = new MvxObservableCollection<ItemContact>();
                    foreach (var cont in contacts.Contacts)
                        tmp.Add(new ItemContact(cont));
                    Items.AddRange(tmp);
                }
                else
                   Mvx.IoCProvider.Resolve<IMessage>().Dialog("Error: Connection problem or server is not responding!", async () => { await PullToRefresh(); });
            }
            catch(Exception ex)
            {
                Mvx.IoCProvider.Resolve<IMessage>().Dialog($"Error: {ex.Message}", async () => { await PullToRefresh(); });
            }
           
        }

        private async Task PullToRefresh()
        {
            IsRefreshing = true;
            page = 1;
            Items.Clear();
            await GetContacts();
            IsRefreshing = false;
        }

        public override void ViewAppeared()
        {
            if(Items.Count == 0)
                Task.Run(PullToRefresh);
            base.ViewAppeared();
        }
    }
}