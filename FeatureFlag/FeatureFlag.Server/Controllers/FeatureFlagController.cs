using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeatureFlag.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureFlagController : ControllerBase
    {
       
        // GET api/<FeatureFlagController>/5
        [HttpGet("{projectName}/{key}")]
        public string Get(string projectName, string key)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] FeatureFlagModel featureFlagModel)
        {
        }

        [HttpPut]
        public void Put([FromBody] FeatureFlagModel featureFlagModel)
        {

        }

        [HttpDelete]
        public void Delete([FromBody] FeatureFlagModel featureFlagModel)
        {
        }
    }
}
