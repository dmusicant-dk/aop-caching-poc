using AopTest.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AopTest.Controllers
{
    public class ValuesController : ApiController
    {
        private ItemService itemService;

        //[Autowired]
        public ValuesController(ItemService itemService)
        {
            this.itemService = itemService;
        }


        // GET api/values
        public IEnumerable<string> Get()
        {
            //IDatabase database = RedisCacheManager.getConnection().GetDatabase();
            //string value = database.StringGet("Item1");

            //ProxyFactory factory = new ProxyFactory(new ItemService());
            //factory.AddAdvice(new CacheableInterceptor());
            //ItemService service = (ItemService ) factory.GetProxy();
            //service.getItem("Item1");

            String value = itemService.getItem("Item1");

            return new string[] { value };
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
    }
}
