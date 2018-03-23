using System.ComponentModel.DataAnnotations;
namespace lostWoods.Models{
    public abstract class BaseEntity{}
    public class Trail : BaseEntity{
        [Required]
        public string trail {get;set;}
        
        [Required]
        [MinLength(10, ErrorMessage="Description must be at least 10 characters!")]
        public string description{get;set;}
        
        [Required(ErrorMessage = "Must fill out length!")]
        public float? length {get;set;}

        [Required(ErrorMessage = "Must fill out elevation change!")]
        public int? elevation{get;set;}

        

        [Key]
        public int id{get;set;}

        
    }
}