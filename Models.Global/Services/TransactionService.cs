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
    public class TransactionService : ITransactionRepository
    {
        private readonly HttpClient _httpClient;
        public TransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IEnumerable<Transaction> Get()
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Transaction").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            IEnumerable<Transaction> categories = JsonSerializer.Deserialize<Transaction[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return categories;
        }
        public void Insert(Transaction transaction)
        {
            string json = JsonSerializer.Serialize(transaction);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync($"api/Transaction/", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
        public void Update(int id, Transaction transaction)
        {
            transaction.Id = id;
            string json = JsonSerializer.Serialize(transaction);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/Transaction/{id}", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
        public void Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/Transaction/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public Transaction GetTransact(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Transaction/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            Transaction transaction = JsonSerializer.Deserialize<Transaction>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return transaction;
        }
    }
}
