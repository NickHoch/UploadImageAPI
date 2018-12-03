using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace UploadImageAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public void UploadImage(string imageBase64)
        {
            var uniqueName = Guid.NewGuid().ToString() + ".jpeg";
            var path = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ImagePath"])
                + uniqueName;
            byte[] imageBytes = Convert.FromBase64String(imageBase64);
            File.WriteAllBytes(path, imageBytes);
        }
    }
}
