using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/Albums")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        // GET: api/Albums
        [HttpGet]
        public List<Album> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Albums.ToList();
            }
        }

        // GET api/Albums/5
        [HttpGet("{AlbumID}")]
        public Album Get(int AlbumID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Albums.Find(AlbumID);
            }
        }

        // POST api/Albums
        [HttpPost]
        public void Post([FromBody] Album album)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Albums.Add(album);
                entities.SaveChanges();
            }
        }

        // PUT api/Albums/5
        [HttpPut("{AlbumID}")]
        public void Put(int AlbumID, [FromBody] Album album)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                album.AlbumID = AlbumID;
                entities.Albums.AddOrUpdate(album);
                entities.SaveChanges();
            }
        }

        // DELETE api/Albums/5
        [HttpDelete("{AlbumID}")]
        public void Delete(int AlbumID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Albums.Remove(entities.Albums.Find(AlbumID));
                entities.SaveChanges();
            }
        }
    }
}
