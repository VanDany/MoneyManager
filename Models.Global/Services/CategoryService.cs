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
    public class CategoryService : ICategoryRepository
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IEnumerable<Category> Get()
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Category").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            IEnumerable<Category> categories = JsonSerializer.Deserialize<Category[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return categories;
        }
        public void Insert(Category category)
        {
            string json = JsonSerializer.Serialize(category);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync($"api/Category/", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
        public void Update(int id, Category category)
        {
            category.Id = id;
            string json = JsonSerializer.Serialize(category);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/Category/{id}", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
        public void Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/Category/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public Category GetCat(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Category/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            Category category = JsonSerializer.Deserialize<Category>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return category;
        }
    }
}
