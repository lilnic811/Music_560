using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using MusicDataAccess;
using System.Data;
using System.Data.Entity.Migrations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Music_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        // GET: api/<MusicController>
        [HttpGet]
        public List<Song> Get()
        {
            using ( MusicDataEntities entities = new MusicDataEntities() )
            {
                return entities.Songs.ToList();
            }
        }

        // GET api/<MusicController>/5
        [HttpGet("{SongID}")]
        public Song Get(int SongID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Songs.Find(SongID);
            }
        }

        // POST api/<MusicController>
        [HttpPost]
        public void Post([FromBody] Song song)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Songs.Add(song);
                entities.SaveChanges();
            }
        }

        // PUT api/<MusicController>/5
        [HttpPut("{SongID}")]
        public void Put(int SongID, [FromBody] Song song)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                song.SongID = SongID;
                entities.Songs.AddOrUpdate(song);
                entities.SaveChanges();
            }
        }

        // DELETE api/<MusicController>/5
        [HttpDelete("{SongID}")]
        public void Delete(int SongID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Songs.Remove(entities.Songs.Find(SongID));
                entities.SaveChanges();
            }
        }
    }
}
