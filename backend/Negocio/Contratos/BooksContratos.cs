using Entities;
using Negocio.IContratos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Negocio.Contratos
{
    public class BooksContratos : IBooksContract<Books>
    {
        private readonly HttpClient _httpClient = null!;

        private const string url = "https://fakerestapi.azurewebsites.net/api/v1/Books/";
       
        public BooksContratos(HttpClient httpClient)
        {
          _httpClient = httpClient;
        }
        
        public  async Task<Books> CreateBooks(Books book)
        {
            var content = JsonConvert.SerializeObject(book);
            var httpResponse = await _httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot add these {book.Title} book, try again");
            }

            var json = JsonConvert.DeserializeObject<Books>(await httpResponse.Content.ReadAsStringAsync());
            return json;
        }

        public async Task DeleteBooks(int id)
        {
            var httpResponse = await _httpClient.DeleteAsync($"{url}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete this book, try again");
            }
        }

        public async Task<List<Books>> GetBooks()
        {
            var httpResponse = await _httpClient.GetAsync(url);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve books");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Books>>(content);

            return tasks;
        }


        public async Task<Books> GetBooksById(int id)
        {
            var httpResponse = await _httpClient.GetAsync($"{url}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve books");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<Books>(content);

            return task;
        }

        public async Task<Books>UpdateBooks(Books books)
        {
            var content = JsonConvert.SerializeObject(books);
            var HttpResponse = await _httpClient.PutAsync($"{url}{books.Id}", new StringContent(content, Encoding.Default, "application/default"));

            if (!HttpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot update this book {books.Title}, try later");
            }
             
            var createdTask = JsonConvert.DeserializeObject<Books>(await HttpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }
    }
}
