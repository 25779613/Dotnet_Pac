using Microsoft.EntityFrameworkCore;


      public class StudentContext : DbContext {
            public StudentContext (DbContextOptions<StudentContext> options) : base (options) { }
            public DbSet<Dotnet_Prac.Models.StudentModel> students_table{ get; set; }
        }
    
    