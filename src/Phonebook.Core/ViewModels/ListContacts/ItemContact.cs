using Phonebook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.Core.ViewModels
{
    public class ItemContact : ContactExtended
    {
        public ItemContact(Contact contact) : base(contact) { }
        public string Photo => $"{_contact.Photo.Thumbnail}";
    }
}
