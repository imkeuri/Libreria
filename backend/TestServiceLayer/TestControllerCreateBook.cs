using Entities;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestServiceLayer
{
    [TestFixture]
    internal class TestControllerCreateBook
    {
        private readonly HttpClient _httpClient = null!;

        private const string url = "https://fakerestapi.azurewebsites.net/api/v1/Books/";

        public TestControllerCreateBook(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [Test]
        public async Task<Books> CreateBooks(Books book)
        {
            var content = JsonConvert.SerializeObject(book);
            var httpResponse = await _httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot add these {book.Title} book, try again");
            }

            var json = JsonConvert.DeserializeObject<Books>(await httpResponse.Content.ReadAsStringAsync());
            Assert.That(json.Title, Is.Null);
            return json;

            
        }
    }
}
