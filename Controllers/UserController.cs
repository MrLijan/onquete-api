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

    [HttpGet]
    public async Task<ActionResult<List<User>>> Index()
    {
      return Ok(await _users.GetAll());
    }

    [HttpGet("{uuid}")]
    public async Task<ActionResult<User>> Find(Guid uuid)
    {
      var user = await _users.GetByUuid(uuid);

      if (user is null)
        return NotFound();

      return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateNewUser([FromBody] CreateUserRequest user)
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