using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public List<User> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Users.ToList();
            }
        }

        // GET api/Users/5
        [HttpGet("{UserID}")]
        public User Get(int UserID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Users.Find(UserID);
            }
        }

        // POST api/Users
        [HttpPost]
        public void Post([FromBody] User user)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Users.Add(user);
                entities.SaveChanges();
            }
        }

        // PUT api/Users/5
        [HttpPut("{UserID}")]
        public void Put(int UserID, [FromBody] User user)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                user.UserID = UserID;
                entities.Users.AddOrUpdate(user);
                entities.SaveChanges();
            }
        }

        // DELETE api/Users/5
        [HttpDelete("{UserID}")]
        public void Delete(int UserID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Users.Remove(entities.Users.Find(UserID));
                entities.SaveChanges();
            }
        }
    }
}
