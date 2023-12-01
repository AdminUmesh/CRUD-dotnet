using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Practice.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<StudentTable> example { get; set; }
    }
}
