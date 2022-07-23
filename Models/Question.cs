using Microsoft.EntityFrameworkCore;

namespace OnqueteApi.Models;

[Index(nameof(Uuid), IsUnique = true)]
public class Question : BaseModel
{
    public int Id { get; set; }
    public Guid Uuid { get; set; }
    public QuestionType QuestionType { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}