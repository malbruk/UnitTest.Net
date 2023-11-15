using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IDataContext _dataContext;

        public EventsController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _dataContext.Events;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            var eve = _dataContext.Events.Find(e => e.Id == id);
            if (eve is null)
            {
                return NotFound();
            }
            return Ok(eve);
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
