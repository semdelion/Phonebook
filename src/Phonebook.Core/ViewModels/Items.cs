using Phonebook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.Core.ViewModels
{
    public class Items
    {
        private Contact _contact;

        public string Photo => $"{_contact.Photo.Thumbnail}";
        public string FullName => $"{FirstCharToUpper(_contact.Name.First)} {FirstCharToUpper(_contact.Name.Last)}";

        public Items(Contact contact) => _contact = contact;

        private static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Eroor: string is null or empry");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
