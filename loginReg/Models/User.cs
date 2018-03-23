using System.ComponentModel.DataAnnotations;


namespace loginReg.Models
{
    public class RegUser : BaseEntity
    {
        [Required]
        [MinLength(2, ErrorMessage="Name must be longer!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="First name can contain letters only")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage="Name must be longer!")]
        
        public string LastName {get; set;}

        [Required]
        [EmailAddress]
        
        
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Must match!")]
        public string PasswordConfirm {get;set;}

    }
   
}