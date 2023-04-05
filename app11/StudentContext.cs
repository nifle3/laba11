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
        public DbSet<User> Users { get; set; }
        public StudentContext() : base("DbConnection") { }
    }
}
