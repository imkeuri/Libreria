using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Negocio.Contratos;
using Negocio.IContratos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestingLibrary
{
    [TestClass]
    public class TestClass
    {
        public HttpClient httpClient { get; set; }
        public Mock<IBooksContract<Books>> Contracts { get; set; }

        [TestInitialize]
        public void ConfigureTesting()
        {
            httpClient = new HttpClient();
            Contracts = new Mock<IBooksContract<Books>>();

            
        }

        [TestMethod]
        [Fact]
        public async  void TestGetAllBooks()
        {
            List<Books> books = new List<Books>()
            {
                new Books() { Id = 1, Title = "Test1",Description = "TestD",Excerpt = "Excefrt",PageCount = 1,PublishDate = DateTime.Now},
                new Books() { Id = 2, Title = "Test1",Description = "TestD",Excerpt = "Excefrt",PageCount = 1,PublishDate = DateTime.Now},
                new Books() { Id = 3, Title = "Test1",Description = "TestD",Excerpt = "Excefrt",PageCount = 1,PublishDate = DateTime.Now},
                new Books() { Id = 4, Title = "Test1",Description = "TestD",Excerpt = "Excefrt",PageCount = 1,PublishDate = DateTime.Now}

            };

            Contracts.Setup(c => c.GetBooks()).Returns(Task.FromResult(books));


            IBooksContract<Books> contractSpy = Contracts.Object;



            var booksTest =await contractSpy.GetBooks();

            Assert.Equals(4, booksTest.Count);


        }

    }
}
