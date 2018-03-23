using Microsoft.EntityFrameworkCore;
 
namespace userDashBoard.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users{get;set;}

        public DbSet<Message> Messages {get;set;}
        public DbSet<Comment> Comments {get;set;}
    }

    
}