using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace SimpleLogger.Services
{
    public abstract class Service
    {
        protected StringContent GetContet(object obj)
            => new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

        protected bool ResponseIsValid(HttpResponseMessage response)
        {
            try
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return WriteError(ex.Message);
            }
        }

        private bool WriteError(string message)
        {
            Console.WriteLine(message);
            return false;
        }
    }
}
