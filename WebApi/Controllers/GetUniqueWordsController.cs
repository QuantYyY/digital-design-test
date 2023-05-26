using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetUniqueWords;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUniqueWordsController : ControllerBase
    {
        [HttpPost(Name = "GetUniqueWords")]
        public ActionResult<Dictionary<string, int>> Post([FromBody] string text)
        {
            UniqueFinder finder = new UniqueFinder();

            var result = finder.GetUniqueWordsMultiThread(text);

            return Ok(result);
        }
    }
}