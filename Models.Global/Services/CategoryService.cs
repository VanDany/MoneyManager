using Models.Global.Data;
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
    public class CategoryService
    {
        private HttpClient CreateHttpClient()
        {
            return new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:44341/")
            };
        }
        public IEnumerable<Category> Get()
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = httpClient.GetAsync("api/Category").Result;
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
        }
        public void Insert(Category category)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(category);

                    using (HttpContent httpContent = new StringContent(json))
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        HttpResponseMessage httpResponseMessage = httpClient.PostAsync($"api/Category/", httpContent).Result;
                        httpResponseMessage.EnsureSuccessStatusCode();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Update(int id, Category category)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(category);

                    using (HttpContent httpContent = new StringContent(json))
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        HttpResponseMessage httpResponseMessage = httpClient.PutAsync($"api/Category/{id}", httpContent).Result;
                        httpResponseMessage.EnsureSuccessStatusCode();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Delete(int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = httpClient.DeleteAsync($"api/Category/{id}").Result;
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Category GetCat(int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"api/Category/{id}").Result;
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
}
