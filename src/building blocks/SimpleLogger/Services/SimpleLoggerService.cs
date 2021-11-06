using SimpleLogger.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleLogger.Services
{
    public class SimpleLoggerService : Service, ISimpleLoggerService
    {
        private readonly HttpClient _httpClient;

        public SimpleLoggerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("");
        }

        public async Task Insert(Log log)
        {
            var content = GetContet(log);

            var response = await _httpClient.PostAsync("", content);

            ResponseIsValid(response);
        }
    }
}
