using System.Collections.Generic;
using System.Web.Http;

namespace WebAuth.Controllers
{
    public class DataController : ApiController
    {
        [Authorize]public IHttpActionResult Get()
        {
            return Ok(new List<string>
            {
                "Some",
                "Some1",
                "Some2",                "Some3"

            });
        }
    }
}
