using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionnaireMW.Models;
using QuestionnaireMW.Repository;

namespace QuestionnaireMW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerResponseController : ControllerBase
    {
        private readonly IAnswerResponseRepository _repository;
        public AnswerResponseController(IAnswerResponseRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Answer
        [HttpGet]

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Answer/5
        [HttpGet("{id}", Name = "Get")]
        [Route("GetAnswerResponseById/{id}")]
        public List<AnswerResponse> Get(int id)
        {
            return _repository.getAnswerResponse(id);
        }

        // POST: api/Answer
        [HttpPost]
        [Route("AddAnswerResponse")]
        public IActionResult Post([FromBody] AnswerResponse item)
        {
            try
            {
                _repository.AddAnswerResponse(item);
                return Ok("Record Added");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Answer/5
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
