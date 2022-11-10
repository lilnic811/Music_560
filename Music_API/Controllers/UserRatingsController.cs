using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/UserRatings")]
    [ApiController]
    public class UserRatingsController : ControllerBase
    {
        // GET: api/UserRatings
        [HttpGet]
        public List<UserRating> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.UserRatings.ToList();
            }
        }

        // GET api/UserRatings/5
        [HttpGet("{UserRatingID}")]
        public UserRating Get(int UserRatingID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.UserRatings.Find(UserRatingID);
            }
        }

        // POST api/UserRatings
        [HttpPost]
        public void Post([FromBody] UserRating userRating)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.UserRatings.Add(userRating);
                entities.SaveChanges();
            }
        }

        // PUT api/UserRatings/5
        [HttpPut("{UserRatingID}")]
        public void Put(int UserRatingID, [FromBody] UserRating userRating)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                userRating.UserRatingID = UserRatingID;
                entities.UserRatings.AddOrUpdate(userRating);
                entities.SaveChanges();
            }
        }

        // DELETE api/UserRatings/5
        [HttpDelete("{UserRatingID}")]
        public void Delete(int UserRatingID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.UserRatings.Remove(entities.UserRatings.Find(UserRatingID));
                entities.SaveChanges();
            }
        }
    }
}
