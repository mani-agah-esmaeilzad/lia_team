namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService _userService)
    {
        this._userService = _userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        try
        {
            return StatusCode(200, await _userService.GetUsersAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] User user)
    {
        try
        {
            await _userService.CreateUsersAsync(user);
            return StatusCode(200, user);
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(User user)
    {
        try
        {
            await _userService.DeleteUsersAsync(user);
            return Ok();
        }
        catch(Exception ex)
        {
            return NotFound();
        }

    }
}
