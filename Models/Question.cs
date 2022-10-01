using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace OnqueteApi.Models;

[Index(nameof(Uuid), IsUnique = true)]
public class Question : BaseModel
{
    public int Id { get; set; }
    public Guid Uuid { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int SurveyId { get; set; }
    
    [JsonIgnore]
    public Survey Survey { get; set; }

    public int QuestionTypeId { get; set; }
}