using Microsoft.AspNetCore.Mvc;
using OnqueteApi.Types;

namespace OnqueteApi.Controllers;

public class AppController : ControllerBase
{
    public AppController() { }

    /// <summary> Generates new success response </summary>
    public ActionResult<AppResponse<object>> Success(string message, object data)
    {
        AppResponse<object> response = new AppResponse<object>()
        {
            Status = "success",
            Message = message,
            Data = data
        };

        return Ok(response);
    }
}
