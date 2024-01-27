using Microsoft.EntityFrameworkCore;
using ProjecktC.Data.Models;

namespace ProjecktC.Data
{

    public class AppDbContext:DbContext
    {
  
            public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
            {
            }

            public DbSet<Books> Books { get; set; }
            public DbSet<Library> Librarys { get; set; }
            public DbSet<Memberships> Memberships { get; set; }
         
    }
}