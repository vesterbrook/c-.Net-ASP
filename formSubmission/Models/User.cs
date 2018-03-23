using System.ComponentModel.DataAnnotations;

namespace formSubmission.Models
{
    public abstract class BaseEnity{}

    public class User : BaseEnity
    {
        [Required]
        [MinLength(2, ErrorMessage="Name must be longer!")]
        public string firstName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage="Name must be longer!")]
        public string lastName {get; set;}

        [Required]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Must match")]
        public string PasswordConfirm {get;set;}
        

        [Required]
        [Range(0,105)]
        public string Age {get; set;}

    }
}