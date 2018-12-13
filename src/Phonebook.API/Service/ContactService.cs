using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Phonebook.API.Models;

namespace Phonebook.API.Service
{
    public class ContactService : BaseServiсe, IContactService
    {
        public ContactService(IConnectionService connectionService) : base(connectionService){}

        public Task<ContactResult> GetContacts(int count, int page = 1)
        {
            return Get<ContactResult>($"{Const.URL}?results={count}&page={page}&seed=1");
        }
    }
}
