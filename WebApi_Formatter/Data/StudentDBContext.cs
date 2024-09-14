using Microsoft.EntityFrameworkCore;
using WebApi_Formatter.Entities;

namespace WebApi_Formatter.Data
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
