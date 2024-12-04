using invoice_system_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace invoice_system_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

    }
}
