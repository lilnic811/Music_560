using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/Genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        // GET: api/Genres
        [HttpGet]
        public List<Genre> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Genres.ToList();
            }
        }

        // GET api/Genres/5
        [HttpGet("{GenreID}")]
        public Genre Get(int GenreID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Genres.Find(GenreID);
            }
        }

        // POST api/Genres
        [HttpPost]
        public void Post([FromBody] Genre genre)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Genres.Add(genre);
                entities.SaveChanges();
            }
        }

        // PUT api/Genres/5
        [HttpPut("{GenreID}")]
        public void Put(int GenreID, [FromBody] Genre genre)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                genre.GenreID = GenreID;
                entities.Genres.AddOrUpdate(genre);
                entities.SaveChanges();
            }
        }

        // DELETE api/Genres/5
        [HttpDelete("{GenreID}")]
        public void Delete(int GenreID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Genres.Remove(entities.Genres.Find(GenreID));
                entities.SaveChanges();
            }
        }
    }
}
