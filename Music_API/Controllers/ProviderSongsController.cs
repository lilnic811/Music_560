using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/ProviderSongs")]
    [ApiController]
    public class ProviderSongsController : ControllerBase
    {
        // GET: api/ProviderSongs
        [HttpGet]
        public List<ProviderSong> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.ProviderSongs.ToList();
            }
        }

        // GET api/ProviderSongs/5
        [HttpGet("{ProviderSongID}")]
        public ProviderSong Get(int ProviderSongID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.ProviderSongs.Find(ProviderSongID);
            }
        }

        // POST api/ProviderSongs
        [HttpPost]
        public void Post([FromBody] ProviderSong providerSong)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.ProviderSongs.Add(providerSong);
                entities.SaveChanges();
            }
        }

        // PUT api/ProviderSongs/5
        [HttpPut("{ProviderSongID}")]
        public void Put(int ProviderSongID, [FromBody] ProviderSong providerSong)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                providerSong.ProviderSongID = ProviderSongID;
                entities.ProviderSongs.AddOrUpdate(providerSong);
                entities.SaveChanges();
            }
        }

        // DELETE api/ProviderSongs/5
        [HttpDelete("{ProviderSongID}")]
        public void Delete(int ProviderSongID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.ProviderSongs.Remove(entities.ProviderSongs.Find(ProviderSongID));
                entities.SaveChanges();
            }
        }
    }
}