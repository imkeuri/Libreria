using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.IContratos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Cors;
namespace PruebaTecnica.Controller
{
   
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BooksController : ControllerBase
    {

        private readonly IBooksContract<Books> _booksContract;

        public BooksController(IBooksContract<Books> booksContract)
        {
            _booksContract = booksContract;
        }

        [HttpGet]
        public async Task<ActionResult<List<Books>>> GetBooks()
        {
            try
            {
                var list_books = await _booksContract.GetBooks();
                return Ok(new {books = list_books});
            }
            catch (Exception message)
            {

                return BadRequest(new { Status = -1, message.Message }); ;
            }
        }
        [HttpGet("GetBookById/{id}")]
        public async Task <ActionResult<Books>> GetBookById (int id)
        {
            try
            {
                var obj_book = await _booksContract.GetBooksById(id);
                return Ok(new { Status = 1, books = obj_book });
            }
            catch (Exception me)
            {

                return BadRequest(new { Status = -1, me.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Books>> CreateBook (Books books)
        {
            try
            {
               var new_book =  await _booksContract.CreateBooks(books);

                return Ok(new { Status = 1, books = new_book });
            }
            catch (Exception me)
            {
                return BadRequest(new { Status = -1, me.Message });
            }
        }
        [HttpPut("UpdateBook/{id}")]
        public async Task<ActionResult<Books>> UpdateBook(Books books)
        {
            try
            {
                var updateBooks = await _booksContract.UpdateBooks(books);

                return Ok(new { Status = 1, book = books  });
            }
            catch (Exception ms)
            {
                return BadRequest(new { Status = -1, ms.Message});
            }
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult> DeleteBook ( int id)
        {
            try
            {
          
            
                  await _booksContract.DeleteBooks(id);
                return Ok(new { Status = -1, Message = "The book was deleted successfully"});

            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = -1, ex.Message });
            }
        }
    }
}
