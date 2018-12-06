using Phonebook.API.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Phonebook.API.Service
{
    public class ConnectionService: IConnectionService
    {
        private Lazy<HttpClient> _httpClient;

        public ConnectionService(HttpMessageHandler httpHandler)
        {
            _httpClient = new Lazy<HttpClient>(()=> new HttpClient (httpHandler));
        }

        private async Task<ResponseResult> SendAsync(string url, HttpContent data = null)
        {
            using (var http = new HttpRequestMessage(data == null ? HttpMethod.Get : HttpMethod.Post, url) {Content = data })
            {
                var answer = await _httpClient.Value.SendAsync(http);
                return new ResponseResult
                {
                    StatusCode = answer.StatusCode,
                    Url = url,
                    Content = answer.Content
                };
            }
        }

        public Task<ResponseResult> Get(string url)
        {
            return SendAsync(url);
        }
        public Task<ResponseResult> Post(string url, HttpContent data)
        {
            return SendAsync(url);
        }
    }
}
