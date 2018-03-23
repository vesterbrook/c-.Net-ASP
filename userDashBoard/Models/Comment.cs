using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace userDashBoard.Models
{
    public class Comment : BaseEntity
    {
        
        public int CommentId {get;set;}
        public string Messages {get;set;}
        public int UserId {get;set;}
        public int MessagesId {get;set;}
        public DateTime created_at {get;set;}
        public User user {get;set;}
    }
}