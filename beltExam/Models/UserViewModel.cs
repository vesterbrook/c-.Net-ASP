using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace beltExam.Models
{
    public abstract class BaseEntity
    {
        // EMPTY!!!
    }
    public class RegUser : BaseEntity
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="First Name must be at least 2 characters!")]
        public string FirstName { get;set; }
    
        [Required]
        [MinLength(2, ErrorMessage="Last Name must be at least 2 characters!")]
        public string LastName { get;set; }

        [Required]
        [EmailAddress]
        public string Email { get;set; }

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters!")]
        [DataType(DataType.Password)]
        public string Password { get;set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get;set; }

        public int UserLevel { get;set; }
    }
    public class LoginUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get;set; }

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters!")]
        [DataType(DataType.Password)]
        public string Password { get;set; }
    }

    public class MessageVal : BaseEntity
    {
        [Required]
        [MinLength(1, ErrorMessage="Message must be filled out!")]
        public string Messages {get;set;}
    }

    public class CommentVal : BaseEntity
    {
        [Required]
        [MinLength(1, ErrorMessage="Comment must be filled out!")]
        public string Comments {get;set;}
    }
}
// MIGRATION NOTES: 
// dotnet ef migrations add FirstMigration
// dotnet ef database update