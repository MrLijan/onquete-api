using Microsoft.AspNetCore.Mvc;
using OnqueteApi.Types;

namespace OnqueteApi.Controllers;

public class AppController : ControllerBase
{
    public AppController() { }

    /// <summary> Generates new success response </summary>
    public ActionResult<AppResponse<T>> Success<T>(string message, T data)
    {
        AppResponse<T> response = new AppResponse<T>()
        {
            Status = "success",
            Message = message,
            Data = data
        };

        return Ok(response);
    }
}
