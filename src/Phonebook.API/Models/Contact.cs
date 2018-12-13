using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.API.Models
{
    public class Contact
    {
        [JsonProperty("picture")]
        public Photo Photo { get; set; }
        public Name Name { get; set; }
        public string Phone { get; }
        public string Email { get; }
    }
}
