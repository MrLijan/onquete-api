namespace OnqueteApi.Models;

public class BaseModel
{
  public DateTime? CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
  public DateTime? DeletedAt { get; set; }

  public BaseModel()
  {
    this.CreatedAt = DateTime.UtcNow;
    this.UpdatedAt = DateTime.UtcNow;
  }
}