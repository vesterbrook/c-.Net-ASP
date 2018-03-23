using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace userDashBoard.Models
{
    public class User : BaseEntity
    {
        
        // These must match your columns in your table database!
        public int UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public int UserLevel {get;set;}
        public string Password {get; set;}
        public string Description {get;set;}
        public DateTime created_at {get;set;}
        public List<Message> Messages{get;set;}      
        public User()
        {
            Messages = new List<Message>();
            UserLevel = 0;
        }
    }
}