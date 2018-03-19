using System.ComponentModel.DataAnnotations;
using System;
namespace rest.Models
{
    public class ValidDateAttribute : ValidationAttribute 
    {
    public override bool IsValid (object value) 
    {
       DateTime d = Convert.ToDateTime (value);
       return d <= DateTime.Now;
    }
    }
public abstract class BaseEntity{}

public class Rest : BaseEntity
{
[Key]
public int RestId {get;set;}

[Required]
[MinLength(2, ErrorMessage="Must be filled out!")]
public string reviewName {get;set;}

[Required]
[MinLength(2, ErrorMessage="Must be filled out!")]
public string restName {get;set;}
[Required]
[MinLength(10, ErrorMessage="Must be filled out!")]
public string review {get;set;}

[Required]
[ValidDate(ErrorMessage ="Date can not be in the future!")]
public DateTime visitDate {get;set;}

[Required]
public int stars {get;set;}


}
}