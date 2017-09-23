using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using NumeneraCypherBook.Core.Models;
using NumeneraCypherBook.Core.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NumeneraCypherBook.API.Controllers
{
    [Route("api/[controller]")]
    public class CyphersController : Controller
    {
        private readonly ICypherRepository _repository;

        public CyphersController(ICypherRepository repository)
        {
            this._repository = repository;
        }

        // GET api/cypher
        [HttpGet]
        public IEnumerable<Cypher> GetAll()
        {
            return _repository.Get().Result;
        }

        [HttpGet("{id}", Name = "GetCypher")]
        public IActionResult GetById(int id)
        {
            var cypher = _repository.Get(id).Result;
            if (cypher == null)
            {
                return NotFound();
            }
            return new ObjectResult(cypher);
        }
    }
}
