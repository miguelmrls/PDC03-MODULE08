using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using PDC03_MODULE08;
using System.IO;
using PDC03_MODULE08.Model;

namespace PDC03_MODULE08.Services
{
    public class DatabaseContext:DbContext
    {

        public DbSet<EmployeeModel> Employee { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated(); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Employee.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
