using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Worker.Data.Entities;

namespace Worker.Web.Data
{
    public class WorkerDataContext:DbContext
    {
        public WorkerDataContext(DbContextOptions<WorkerDataContext> options)
         : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
              .HasOne<Customer>(s => s.Customer)
              .WithMany(g => g.Loans)
              .HasForeignKey(s => s.CustId);

            modelBuilder.Entity<Payment>()
            .HasOne<Loan>(s => s.loan)
            .WithMany(g => g.Payments)
            .HasForeignKey(s => s.LoanNumber);


        }

        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<Loan> tblloan { get; set; }
        public DbSet<Logger> tblLogger { get; set; }
        public DbSet<Payment> tblPayment { get; set; }

    }
}
