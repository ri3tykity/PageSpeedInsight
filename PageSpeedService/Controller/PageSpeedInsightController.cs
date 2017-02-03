using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PSA;

namespace PageSpeedService.Controller
{
    public class PageSpeedInsightController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        // GET URL FROM USER / APPLICATION
        public HttpResponseMessage Get(string queryString)
        {
            PageSpeedCore psc = new PageSpeedCore();
            var result = psc.FetchURL(queryString);
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, result);
            return res;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}