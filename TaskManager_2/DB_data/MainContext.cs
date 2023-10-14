using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace TaskManager_2.DB_data
{
    internal class MainContext : DbContext
    {
        private readonly string connectionHome = "Data Source=localhost;Initial Catalog=TaskManager_PB42;Trusted_Connection=True;TrustServerCertificate=True";
        public readonly string connectionAKVT = "Data Source=192.168.221.12;Initial Catalog=TaskManager_PB42;User ID=user04;Password=04;TrustServerCertificate=True";
        public MainContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionHome);
        }
    }
}
