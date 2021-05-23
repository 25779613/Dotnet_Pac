using Microsoft.EntityFrameworkCore;

namespace Dotnet_Prac.Models
{
      public class StudentContext : DbContext {
            public StudentContext (DbContextOptions<StudentContext> options) : base (options) { }
            public DbSet<StudentModel> students { get; set; }
        }
    }
    