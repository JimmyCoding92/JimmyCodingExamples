using DockerExampleWithSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerExampleWithSQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}