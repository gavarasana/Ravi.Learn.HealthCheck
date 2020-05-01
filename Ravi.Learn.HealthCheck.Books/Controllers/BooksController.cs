using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ravi.Learn.HealthCheck.Books.Dxos;
using Ravi.Learn.HealthCheck.Books.Entities;
using Ravi.Learn.HealthCheck.Books.Models.Response;
using Ravi.Learn.HealthCheck.Books.Repositories;

namespace Ravi.Learn.HealthCheck.Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IEntityDxo<Book, BookResponse> _bookDxo;

        public BooksController(IRepository<Book> bookRepository, IEntityDxo<Book, BookResponse> bookDxo)
        {
            _bookRepository = bookRepository;
            _bookDxo = bookDxo;
        }

        // GET: api/Books
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult< BookResponse>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(id, cancellationToken);
            if (book == null)
                return NotFound();
            return _bookDxo.MapTo(book);
        }

        // GET: api/Books/5
        
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Books
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Books/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
