using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;

namespace Phonebook.API.Models
{
    public class ResponseResult
    {
        public string Url { get; set; }
        public HttpContent Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
