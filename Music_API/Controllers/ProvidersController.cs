using Microsoft.AspNetCore.Mvc;
using MusicDataAccess;
using System.Data.Entity.Migrations;

namespace Music_API.Controllers
{
    [Route("api/Providers")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        // GET: api/Providers
        [HttpGet]
        public List<Provider> Get()
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Providers.ToList();
            }
        }

        // GET api/Providers/5
        [HttpGet("{ProviderID}")]
        public Provider Get(int ProviderID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                return entities.Providers.Find(ProviderID);
            }
        }

        // POST api/Providers
        [HttpPost]
        public void Post([FromBody] Provider provider)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Providers.Add(provider);
                entities.SaveChanges();
            }
        }

        // PUT api/Providers/5
        [HttpPut("{ProviderID}")]
        public void Put(int ProviderID, [FromBody] Provider provider)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                provider.ProviderID = ProviderID;
                entities.Providers.AddOrUpdate(provider);
                entities.SaveChanges();
            }
        }

        // DELETE api/Providers/5
        [HttpDelete("{ProviderID}")]
        public void Delete(int ProviderID)
        {
            using (MusicDataEntities entities = new MusicDataEntities())
            {
                entities.Providers.Remove(entities.Providers.Find(ProviderID));
                entities.SaveChanges();
            }
        }
    }
}
