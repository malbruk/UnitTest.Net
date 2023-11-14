using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDataContext _dataContext;

        public ValuesController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _dataContext.Values;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{val}")]
        public ActionResult<string> Get(string val)
        {
            var value = _dataContext.Values.Find(v => v == val);
            if(string.IsNullOrEmpty(value))
            {
                return NotFound();
            }
            return Ok(value);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
