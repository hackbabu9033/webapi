using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace exercise.Controllers
{
    public class HelloController : ApiController
    {
        // GET: api/Hello
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Hello/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hello
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Hello/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hello/5
        public void Delete(int id)
        {
        }
    }
}
