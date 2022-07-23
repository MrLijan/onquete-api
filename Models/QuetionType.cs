using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnqueteApi.Models;

[Index(nameof(Name), IsUnique = true)]
public class QuestionType
{
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Name { get; set; } = string.Empty;

    public QuestionType(string name)
    {
        this.Name = name;
    }
}