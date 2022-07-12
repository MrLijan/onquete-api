using Microsoft.EntityFrameworkCore;

namespace OnqueteApi.Models;

[Index(nameof(Uuid),IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User : BaseModel
{
  public int Id { get; set; }
  public Guid Uuid { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
}