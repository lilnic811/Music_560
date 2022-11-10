using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/Songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        // GET: api/Songs
        [HttpGet]
        public List<Song> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Songs.ToList();
            }
        }

        // GET api/Songs/5
        [HttpGet("{SongID}")]
        public Song Get(int SongID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Songs.Find(SongID);
            }
        }

        // POST api/Songs
        [HttpPost]
        public void Post([FromBody] Song song)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Songs.Add(song);
                entities.SaveChanges();
            }
        }

        // PUT api/Songs/5
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

        // DELETE api/Songs/5
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
