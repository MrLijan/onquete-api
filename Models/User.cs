using Microsoft.EntityFrameworkCore;

namespace OnqueteApi.Models;

[Index(nameof(Uuid), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User : BaseModel
{
    public int Id { get; set; }
    public Guid Uuid { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}