using System.ComponentModel.DataAnnotations;

namespace OnqueteApi.Types;

public class NewQuestion
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = String.Empty;

    [StringLength(255)]
    public string Description { get; set; } = String.Empty;

    [Required]
    public int QuestionType { get; set; }
}