using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models
{
    public class Training_Academy:DbContext
    {
        
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }

        public Training_Academy() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-C6MRUHG;Initial Catalog=TrainingAcademy;Integrated Security=True;Encrypt=False");
        }

    }
}
