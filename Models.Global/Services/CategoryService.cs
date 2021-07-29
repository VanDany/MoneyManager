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
        //private HttpClient CreateHttpClient()
        //{
        //    return new HttpClient()
        //    {
        //        BaseAddress = new Uri("https://localhost:44384/")
        //    };
        //}
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IEnumerable<Category> Get(int userId)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Category/{userId}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                IEnumerable<Category> categories = JsonSerializer.Deserialize<Category[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return categories;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void Insert(Category category)
        {
            try
            {
                string json = JsonSerializer.Serialize(category);

                using (HttpContent httpContent = new StringContent(json))
                {
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage httpResponseMessage = _httpClient.PostAsync($"api/Category/", httpContent).Result;
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Update(int id, Category category)
        {
            try
            {
                string json = JsonSerializer.Serialize(category);

                using (HttpContent httpContent = new StringContent(json))
                {
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/Category/{id}", httpContent).Result;
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(int userid, int id)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/Category/{userid}/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Category GetCat(int userId, int id)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Category/{userId}/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                Category category = JsonSerializer.Deserialize<Category>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return category;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
