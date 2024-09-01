using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class appDbContext :DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options)
         : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet <User> Users { get; set; }
    }
}
