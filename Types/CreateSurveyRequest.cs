using System.ComponentModel.DataAnnotations;
using OnqueteApi.Models;

namespace OnqueteApi.Types;

public class CreateSurveyRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    [Required]
    [StringLength(100)]
    public string Description { get; set; }

    [Required]
    public int AuthorId { get; set; }

    public List<Question> Questions { get; set; }
}