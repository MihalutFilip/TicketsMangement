using Repository.models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MatchController : ApiController
    {
        IServices service = DependenciesFactory.GetService();

        // GET api/match
        public IEnumerable<MatchAPI> Get()
        {
            return service.GetAllMatches().Select(match =>
                new MatchAPI()
                {
                    Id = match.Id,
                    Name = match.Name,
                    PlacesRemaining = match.PlacesRemaining,
                    Price = match.Price
                }
            ); ;
        }

        // GET api/match/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/match
        public void Post([FromBody]string value)
        {
        }

        // PUT api/match/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/match/5
        public void Delete(int id)
        {
        }
    }
}
