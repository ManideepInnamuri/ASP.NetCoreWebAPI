using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Models;

namespace QuotesApi.Controllers
{
    [Route("api/Quotes")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        static List<Quote> quotes = new List<Quote>()
        {
            new Quote(){Id =0,Author="Manideep Innamuri",Title="I am the King",Description="Just a Joke"},
            new Quote(){Id=1,Author="Satya Innamuri",Title="Always Belive",Description="Always Believe Yourself"}
        };

        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return quotes;
        }

        public void Post(Quote quote)
        {
            quotes.Add(quote);
        }
    }
}