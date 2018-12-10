using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API.Service;
using System;

namespace Phonebook.Core.ViewModels
{
    public class ContactsViewModel : MvxViewModel
    {
        readonly IContactService _contactService;
        readonly IMvxNavigationService _navigationService;

        public ContactsViewModel(IMvxNavigationService navigationService, IContactService contactService)
        {
            _navigationService = navigationService;
            _contactService = contactService;
        }
        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private async void ResetText()
        {
            var contacts = await _contactService.GetContacts(SettingsConstants.CountOfContacts, SettingsConstants.CountOfPage);
            var tmp = "";
            foreach (var t in contacts.Contacts)
                tmp += Convert.ToString(t.Name.First) + "\n";
            Text = tmp;
        }

        private string _text = "data";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}