using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.API.Models
{
    public class ContactResult
    {
        [JsonProperty("results")]
        public List<Contact> Contacts { get; set; }
    }
}
