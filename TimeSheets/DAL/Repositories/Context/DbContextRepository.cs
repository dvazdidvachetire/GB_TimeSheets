using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Repositories.Context
{
    internal sealed class DbContextRepository : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public DbContextRepository(DbContextOptions<DbContextRepository> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
