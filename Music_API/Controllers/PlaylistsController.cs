using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/Playlists")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        // GET: api/Playlists
        [HttpGet]
        public List<Playlist> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Playlists.ToList();
            }
        }

        // GET api/Playlists/5
        [HttpGet("{PlaylistID}")]
        public Playlist Get(int PlaylistID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Playlists.Find(PlaylistID);
            }
        }

        // POST api/Playlists
        [HttpPost]
        public void Post([FromBody] Playlist playlist)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Playlists.Add(playlist);
                entities.SaveChanges();
            }
        }

        // PUT api/Playlists/5
        [HttpPut("{PlaylistID}")]
        public void Put(int PlaylistID, [FromBody] Playlist playlist)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                playlist.PlaylistID = PlaylistID;
                entities.Playlists.AddOrUpdate(playlist);
                entities.SaveChanges();
            }
        }

        // DELETE api/Playlists/5
        [HttpDelete("{PlaylistID}")]
        public void Delete(int PlaylistID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Playlists.Remove(entities.Playlists.Find(PlaylistID));
                entities.SaveChanges();
            }
        }
    }
}
