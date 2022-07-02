namespace OnqueteApi.Models;

public class User
{
  public int Id { get; set; }
  public Guid Uuid { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  
  // Timestamps
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public DateTime DeletedAt { get; set; }
}