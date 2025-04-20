using Microsoft.EntityFrameworkCore;
using UserManagement.Models.Domain;

namespace UserManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        } 
        public DbSet<User> Users { get; set; }
    }
}
