using System.ComponentModel.DataAnnotations;

namespace OnqueteApi.Types;

public class NewSurvey
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = String.Empty;

    [Required]
    [StringLength(100)]
    public string Description { get; set; } = String.Empty;

    [Required]
    public int AuthorId { get; set; }

    public List<NewQuestion> Questions { get; set; }
}

