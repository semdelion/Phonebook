using Phonebook.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.API.Service
{
    abstract class BaseServise
    {
        IConnectionService ConnectionService { get;}
        protected BaseServise(IConnectionService connectionService) 
        {
            ConnectionService = connectionService;
        }

        private async Task<T> ParsResult<T>(ResponseResult answer)
        {
            return answer.StatusCode == System.Net.HttpStatusCode.OK ? 
                Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await answer.Content.ReadAsStringAsync()) : 
                default(T);
        }

        protected virtual async Task<T> Get<T>(string url) where T : class, new()
        {
            return await ParsResult<T>(await ConnectionService.Get(url));
        }

        protected virtual async Task<T> Post<T>(string url, HttpContent httpContentPost) where T : class, new()
        {
            return await ParsResult<T>(await ConnectionService.Post(url, httpContentPost));
        }
    }
}
