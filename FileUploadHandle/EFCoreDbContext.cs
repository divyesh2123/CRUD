using FileUploadHandle.Models;
using Microsoft.EntityFrameworkCore;

namespace FileUploadHandle
{
    public class EFCoreDbContext: DbContext
    {
        public EFCoreDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-BLNTEBH7\SQLEXPRESS;Database=FileHandlingDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
       
        public DbSet<Employee> Employees { get; set; }
    }
}
