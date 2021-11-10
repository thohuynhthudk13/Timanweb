using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TIMAN.Model;

namespace TIMAN.Web.Services
{
    public class LoginApiClient : ILoginApiClient
    {
        public HttpClient _httpClient;
        public LoginApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
       
        public async Task<bool> Login(Login login)
        {
            var result = await _httpClient.PostAsJsonAsync($"/api/Login/Login", login);
            return result.IsSuccessStatusCode;
        }
    }
}
