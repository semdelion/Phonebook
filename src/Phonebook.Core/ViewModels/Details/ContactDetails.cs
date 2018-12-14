using MvvmCross.ViewModels;
using Phonebook.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.ViewModels.Details
{
    public class ContactDetails : ContactExtended
    {
        public ContactDetails(Contact contact) : base(contact) { }
        public string Photo => $"{_contact.Photo.Large}";
        public string Mail => $"E-mail: \n{_contact.Email}";
        public string Phone => $"Phone: \n{_contact.Phone}";
    }
}

