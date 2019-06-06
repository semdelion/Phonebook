using Phonebook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.Core.ViewModels
{
    public abstract class ContactExtended
    {
        public Contact _contact;

        public string FullName => $"{FirstCharToUpper(_contact.Name.First)} {FirstCharToUpper(_contact.Name.Last)}";

        public ContactExtended(Contact contact) => _contact = contact;

        private static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Eroor: string is null or empry");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
