using Phonebook.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.API.Service
{
    interface IContactService
    {
        Task<ContactResult> GetContacts(int count, int page);
    }
}
