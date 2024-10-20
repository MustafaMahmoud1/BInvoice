using Microsoft.EntityFrameworkCore;

namespace BInvoice.DataModels.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoiceLines)
                .WithOne(il => il.Invoice)
                .HasForeignKey(il => il.InvoiceId);

            modelBuilder.Entity<InvoiceLine>()
                .HasMany(il => il.Taxes)
                .WithOne(t => t.InvoiceLine)
                .HasForeignKey(t => t.InvoiceLineId);

            modelBuilder.Entity<InvoiceLine>()
                .HasOne(il => il.Item)
                .WithMany(i => i.InvoiceLines)
                .HasForeignKey(il => il.ItemId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
