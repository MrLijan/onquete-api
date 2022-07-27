using Microsoft.AspNetCore.Mvc;

namespace OnqueteApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        // constructor
        public HealthController() { }

        public class HealthResponse
        {
            public string Message = string.Empty;
            public int Code;
        }

        // methods
        [HttpGet]
        public ActionResult<HealthResponse> healthCheck()
        {
            var response = new HealthResponse();
            response.Code = 200;
            response.Message = "OK";

            return Ok(response);
        }
    }
}