using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app11
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Users => Set<Student>();
        public StudentContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=StudentDb.db");
        }
    }
}
