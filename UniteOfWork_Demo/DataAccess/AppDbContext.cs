using Microsoft.EntityFrameworkCore;
using UniteOfWork_Demo.Models;

namespace UniteOfWork_Demo.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Book>? Books { get; set; }
    }
}
