namespace StudentsAffairs.INNOTECH.APIs.Controllers;

[Route("errors/{code}")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    public ActionResult Error(int code) 
        => NotFound(new ApiResponse(code, "Not Found EndPoint"));
}
