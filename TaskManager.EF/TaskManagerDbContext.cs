using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.EF.Configurations;
using TaskManager.EF.Models;

namespace TaskManager.EF
{
    public class TaskManagerDbContext : DbContext
    {
        private readonly string _connectionString;

        public TaskManagerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public TaskManagerDbContext()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskManager.EntityFramework;Integrated Security=True;Encrypt=True";
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object value = optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
