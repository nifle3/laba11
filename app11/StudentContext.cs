using Microsoft.EntityFrameworkCore;

namespace app11
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Users => Set<Student>();
        public StudentContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Laba11Usersasdb;Trusted_Connection=True;");
        }
    }
}
