using Models.Global.Data;
using Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Models.Global.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public User Login(string email, string password)
        {
            string json = JsonSerializer.Serialize(new { email, password });
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/auth/login", httpContent).Result;
            return httpResponseMessage.IsSuccessStatusCode ? JsonSerializer.Deserialize<User>(httpResponseMessage.Content.ReadAsStringAsync().Result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) : null;
        }

        public void Register(User user)
        {
            string json = JsonSerializer.Serialize(user);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/auth/login", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
