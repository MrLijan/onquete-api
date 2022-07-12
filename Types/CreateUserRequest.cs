using System.ComponentModel.DataAnnotations;

namespace OnqueteApi.Types;

public class CreateUserRequest
{
  [Required]
  [StringLength(100, ErrorMessage = "FirstName field allowed length is 100")]
  public string FirstName { get; set; }
  
  [Required]
  [StringLength(100, ErrorMessage = "LastName field allowed length is 100")]
  public string LastName { get; set; }
  
  [Required]
  [EmailAddress]
  public string Email { get; set; }
}