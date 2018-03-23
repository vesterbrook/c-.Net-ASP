using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace userDashBoard.Models
{
    public class Message : BaseEntity
    {
        public int MessageId {get;set;}
        public string Messages {get;set;}
        public int ProfileId {get;set;}
        public int UserId {get;set;}
        public int CommentsId {get;set;}
        public DateTime created_at {get;set;}
        public User user {get;set;}
        public List<Comment> Comments{get;set;}
        public Message()
        {
            Comments = new List<Comment>();
            created_at = DateTime.Now;
        }
    }
}