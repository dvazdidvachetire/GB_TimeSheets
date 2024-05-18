using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Repositories.Context;

public sealed class DbContextRepository : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<TimeSheet> TimeSheets { get; set; }
    public DbSet<User> Users { get; set; }

    public DbContextRepository(DbContextOptions<DbContextRepository> options) : base(options)
    {
    }
}
