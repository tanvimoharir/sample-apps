using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        public BooksController(BookService bookservice)
        {
            _bookService=bookservice;
        }
        [HttpGet]
        public ActionResult<List<Books>> Get() =>_bookService.Get();

        [HttpGet("{id:length(24)}",Name="GetBook")]
        public ActionResult<Books> Get(string id)
        {
            var book=_bookService.Get(id);

            if (book==null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Books> Create(Books book)
        {
            _bookService.Create(book);
            return CreatedAtRoute("GetBook",new{IDictionary=book.Id.ToString()},book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id,Books bookIn)
        {
            var book=_bookService.Get(id);

            if (book==null)
            {
                return NotFound();
            }

            _bookService.Update(id,bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book=_bookService.Get(id);

            if (book==null)
            {
                return NotFound();
            }
            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}

//The above defined controller uses the BookService class to perform CRUD operations
//Contains action methods to support GET,POST,PUT and DELETE HTTP requests
//Calls <xref.System>Web.Http>Api.Contoller.CreatedAtRoute*> in the Create action
// method to return a HTTP 201 response whihc is the standard response for HTTP POST method that
//creates new resource on the server
//CreatedAtRoute also adds a Location header to the response.The Location header specifies
//URI of the newly created book