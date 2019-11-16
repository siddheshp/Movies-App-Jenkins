using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_EF_Identity.Data;
using MVC_EF_Identity.Models;

namespace Movies_M2M_WebAPI_RepoPattern_EF_CodeFirst_Identity.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IRepository repository;
        public MoviesController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return repository.GetMovies();
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
