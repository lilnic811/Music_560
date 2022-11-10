using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using MusicDataAccess;
using System.Data;
using System.Data.Entity.Migrations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Music_API.Controllers
{
    [Route("api/Music")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        // GET: api/Music
        [HttpGet]
        public List<object> Get()
        {
            return new List<object>() { new object() };
        }

        // GET api/Music/5
        [HttpGet("{ID}")]
        public object Get(int ID)
        {
            return new object();
        }

        // POST api/Music
        [HttpPost]
        public void Post([FromBody] object Somthing)
        {

        }

        // PUT api/Music/5
        [HttpPut("{ID}")]
        public void Put(int ID, [FromBody] object Somthing)
        {
            
        }

        // DELETE api/Music/5
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {

        }
    }
}
