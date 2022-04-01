using Microsoft.EntityFrameworkCore;
using TodoApiDTO.Core.Models;

namespace TodoApiDTO.DAL.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
