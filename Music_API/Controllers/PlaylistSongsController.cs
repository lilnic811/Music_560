using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/PlaylistSongs")]
    [ApiController]
    public class PlaylistSongsController : ControllerBase
    {
        // GET: api/PlaylistSongs
        [HttpGet]
        public List<PlaylistSong> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.PlaylistSongs.ToList();
            }
        }

        // GET api/PlaylistSongs/5
        [HttpGet("{PlaylistSongID}")]
        public PlaylistSong Get(int PlaylistSongID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.PlaylistSongs.Find(PlaylistSongID);
            }
        }

        // POST api/PlaylistSongs
        [HttpPost]
        public void Post([FromBody] PlaylistSong playlistSong)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.PlaylistSongs.Add(playlistSong);
                entities.SaveChanges();
            }
        }

        // PUT api/PlaylistSongs/5
        [HttpPut("{PlaylistSongID}")]
        public void Put(int PlaylistSongID, [FromBody] PlaylistSong playlistSong)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                playlistSong.PlaylistSongID = PlaylistSongID;
                entities.PlaylistSongs.AddOrUpdate(playlistSong);
                entities.SaveChanges();
            }
        }

        // DELETE api/PlaylistSongs/5
        [HttpDelete("{PlaylistSongID}")]
        public void Delete(int PlaylistSongID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.PlaylistSongs.Remove(entities.PlaylistSongs.Find(PlaylistSongID));
                entities.SaveChanges();
            }
        }
    }
}
