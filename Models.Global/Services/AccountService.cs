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
    public class AccountService : IAccountRepository
    {
        //}
        private readonly HttpClient _httpClient;
        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IEnumerable<Account> Get()
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Account").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            IEnumerable<Account> accounts = JsonSerializer.Deserialize<Account[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return accounts;
        }
        public void Insert(Account account)
        {
            string json = JsonSerializer.Serialize(account);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync($"api/Account/", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
        public void Update(int id, Account account)
        {
            account.Id = id;
            string json = JsonSerializer.Serialize(account);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/Account/{id}", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
        public void Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/Account/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public Account GetAccount(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Account/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            Account account = JsonSerializer.Deserialize<Account>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return account;
        }
    }
}
