using Microsoft.AspNetCore.Mvc;
using OnqueteApi.Services;
using OnqueteApi.Models;
using OnqueteApi.Types;

namespace OnqueteApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class UserController : ControllerBase
  {
    private readonly UserService _users;

    public UserController(UserService userService)
    {
      _users = userService;
    }
    
    // List all Users
    [HttpGet]
    public async Task<ActionResult<List<User>>> Index()
    {
      return Ok(await _users.GetAll());
    }

    // Get User by its UUID
    [HttpGet("{uuid}")]
    public async Task<IActionResult> Find([FromRoute] Guid uuid)
    {
      var user = await _users.GetByUuid(uuid);

      if (user is null)
        return NotFound();
      
      return Ok(user);
    }

    // Create new user
    [HttpPost]
    public async Task<IActionResult> CreateNewUser([FromBody] CreateUserRequest user)
    {
      if (!ModelState.IsValid)
        return BadRequest("User form is not valid");

      var newUser = await _users.Add(user);
      if (newUser is null)
        return BadRequest("General Error, User might be registered");

      return Ok(user);
    }
  }
}