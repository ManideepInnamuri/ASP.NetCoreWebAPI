using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Data;
using QuotesApi.Models;

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        QuotesDBContext quotesDBContext;
        public QuotesController(QuotesDBContext quotesDBContext)
        {
            this.quotesDBContext = quotesDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(quotesDBContext.Quotes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quote = quotesDBContext.Quotes.SingleOrDefault(q => q.Id == id);
            if (quote == null)
                return NotFound();
            return Ok(quote);
        }

        [HttpGet("[action]/{id}")]
        public int Test(int id)
        {
            return id;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            quotesDBContext.Quotes.Add(quote);
            quotesDBContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
            var quoteInDB = quotesDBContext.Quotes.Find(id);
            if (quoteInDB == null)
                return NotFound("No record Found Against this Id");
            quoteInDB.Title = quote.Title;
            quoteInDB.Author = quote.Author;
            quoteInDB.Description = quote.Description;
            quoteInDB.Type = quote.Type;
            quoteInDB.CreatedAt = quote.CreatedAt;
            quotesDBContext.SaveChanges();
            return Ok("Record Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quoteInDB = quotesDBContext.Quotes.Find(id);
            if (quoteInDB == null)
                return NotFound("No record Found Against this Id");
            quotesDBContext.Remove(quoteInDB);
            quotesDBContext.SaveChanges();
            return Ok("Quote Deleted...");
        }
    }
}