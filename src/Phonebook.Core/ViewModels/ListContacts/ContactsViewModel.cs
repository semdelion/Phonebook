using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API.Models;
using Phonebook.API.Service;
using Phonebook.Core.ViewModels.Details;
using System;
using System.Threading.Tasks;

namespace Phonebook.Core.ViewModels
{
    public class ContactsViewModel : MvxViewModel<Contact>
    {
        #region Fields
        private int _page = 1;
        private Contact _contact;
        #endregion

        #region Commands
        private IMvxCommand _refreshContactsCommand;
        public IMvxCommand RefreshContactsCommand => _refreshContactsCommand ?? (_refreshContactsCommand = new MvxAsyncCommand(PullToRefresh));

        private IMvxCommand _gettingCommand;
        public IMvxCommand GettingContactsCommand => _gettingCommand ?? (_gettingCommand = new MvxAsyncCommand(GetContacts));

        private IMvxCommand _itemSelectedCommand;
        public IMvxCommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new MvxAsyncCommand<ItemContact>(NavigateToDetails));
        #endregion

        #region Properties
        private MvxObservableCollection<ItemContact> _items;
        public MvxObservableCollection<ItemContact> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        #endregion

        #region Services
        protected IContactService ContactService { get; }
        protected IMvxNavigationService NavigationService { get; }
        protected IMessage Message { get; }
        #endregion

        #region Constructors
        public ContactsViewModel(IMvxNavigationService navigationService, IContactService contactService, IMessage message)
        {
            NavigationService = navigationService;
            ContactService = contactService;
            Message = message;
            _items = new MvxObservableCollection<ItemContact>();
        }
        #endregion

        #region Private
        private async Task GetContacts()
        {
            try
            {
                var contacts = await ContactService.GetContacts(SettingsConstants.CountOfContacts, _page).ConfigureAwait(false);
                if (contacts != null && contacts.Contacts.Count == SettingsConstants.CountOfContacts)
                {
                    _page++;
                    var tmp = new MvxObservableCollection<ItemContact>();
                    foreach (var cont in contacts.Contacts)
                        tmp.Add(new ItemContact(cont));
                    Items.AddRange(tmp);
                }
                else
                    Message.Dialog("Error: Connection problem or server is not responding!", async () => { await PullToRefresh(); });
            }
            catch (Exception ex)
            {
                Message.Dialog($"Error: {ex.Message}", async () => { await PullToRefresh(); });
            }
        }
        private async Task PullToRefresh()
        {
            IsRefreshing = true;
            _page = 1;
            Items.Clear();
            await GetContacts();
            IsRefreshing = false;
        }

        private Task<bool> NavigateToDetails(ItemContact item)
        {
            return NavigationService.Navigate<DetailsViewModel, Contact>(item._contact); 
        }
        #endregion

        #region Public
        public override void ViewCreated()
        {
            Task.Run(PullToRefresh);
            base.ViewCreated();
        }

        public override void Prepare(Contact parameter)
        {
            _contact = parameter;
        }
        #endregion
    }
}