using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class Izpit3Context : DbContext
    {
        public Izpit3Context()
        {

        }
        public Izpit3Context(DbContextOptions options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DR145US\\SQLEXPRESS;Database=Izpit3DB;Trusted_Connection=True;");
            }
        }
        public DbSet<Company> Companies { get; set; }
        
        public DbSet<Person> People { get; set; }
        
        public DbSet<Game> Games { get; set; }
        

    
    }
}
