using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyStructure.Models;

namespace CompanyStructure
{
    public class AppContext : DbContext
    {
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=CompanyStructure;Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
