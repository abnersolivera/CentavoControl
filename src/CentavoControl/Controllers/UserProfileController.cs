namespace CentavoControl.Controllers;

[Route("[controller]")]
[ApiController]
public class UserProfileController : Controller
{
    /// <summary>
    /// Gets the user profile information.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("User Profile Endpoint");
    }
}