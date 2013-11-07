using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleAPIService;

namespace SimpleWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        IAPIService _service;

        public ValuesController(IAPIService Service)
        {
            _service = Service;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            var value = _service.GetValue_ByID(id);
            if (value !=null)
                return value.Name;
            else
                return null;
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
            _service.DeleteValue(id);
        }
    }
}
