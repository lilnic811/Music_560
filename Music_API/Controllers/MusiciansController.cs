using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/Musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        // GET: api/Musicians
        [HttpGet]
        public List<Musician> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Musicians.ToList();
            }
        }

        // GET api/Musicians/5
        [HttpGet("{MusicianID}")]
        public Musician Get(int MusicianID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Musicians.Find(MusicianID);
            }
        }

        // POST api/Musicians
        [HttpPost]
        public void Post([FromBody] Musician musician)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Musicians.Add(musician);
                entities.SaveChanges();
            }
        }

        // PUT api/Musicians/5
        [HttpPut("{MusicianID}")]
        public void Put(int MusicianID, [FromBody] Musician musician)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                musician.MusicianID = MusicianID;
                entities.Musicians.AddOrUpdate(musician);
                entities.SaveChanges();
            }
        }

        // DELETE api/Musicians/5
        [HttpDelete("{MusicianID}")]
        public void Delete(int MusicianID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Musicians.Remove(entities.Musicians.Find(MusicianID));
                entities.SaveChanges();
            }
        }
    }
}
