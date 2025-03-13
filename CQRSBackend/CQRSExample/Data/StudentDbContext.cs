using CQRSExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Data
{
    public class StudentDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public StudentDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
            
        public DbSet<Student> Students { get; set; }
    }
}
