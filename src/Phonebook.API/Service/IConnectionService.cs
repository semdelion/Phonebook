using Phonebook.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.API.Service
{
    public interface IConnectionService
    {
        Task<ResponseResult> Get(string url);
        Task<ResponseResult> Post(string url, HttpContent data);
    }
}
