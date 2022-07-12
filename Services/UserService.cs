using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OnqueteApi.Models;
using OnqueteApi.Data;
using OnqueteApi.Types;

namespace OnqueteApi.Services;

public class UserService
{
  // Const
  private readonly DataContext ctx;
  private readonly ILogger<UserService> _logger;

  // Constructor
  public UserService(DataContext dataContext, ILogger<UserService> logger)
  {
    ctx = dataContext;
    _logger = logger;
  }

  //Methods
  public async Task<ActionResult<List<User>>> GetAll()
  {
    return await ctx.users.ToListAsync();
  }

  public async Task<ActionResult<User?>> GetByUuid(Guid uuid)
  {
    return await ctx.users.FirstOrDefaultAsync(u => u.Uuid == uuid);
  }

  public async Task<ActionResult<User?>> Add(CreateUserRequest user)
  {
    User newUser = new User()
    {
      Uuid = this.newGuid(),
      FirstName = user.FirstName,
      LastName = user.LastName,
      Email = user.Email
    };

    var action = ctx.users.Add(newUser);
    await ctx.SaveChangesAsync();

    return await ctx.users.FirstOrDefaultAsync(u => u.Uuid == newUser.Uuid);
  }

  private Guid newGuid()
  {
    return Guid.NewGuid();
  }
}