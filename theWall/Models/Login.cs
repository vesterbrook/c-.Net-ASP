using System.ComponentModel.DataAnnotations;


namespace theWall.Models
{
 public abstract class BaseEntity{}
 public class LoginUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        [MinLength(2)]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password{get;set;}
    }
}