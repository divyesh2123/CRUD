using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2;

public partial class SmsInfoContext : DbContext
{
    public SmsInfoContext()
    {
    }

    public SmsInfoContext(DbContextOptions<SmsInfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

    public virtual DbSet<StudentInformation> StudentInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-BLNTEBH7\\SQLEXPRESS;Database=SMS_INFO;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.ToTable("Email_Template");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmailSubject).HasMaxLength(50);
            entity.Property(e => e.EmailTemplateName).HasMaxLength(50);
        });

        modelBuilder.Entity<StudentInformation>(entity =>
        {
            entity.ToTable("Student_Information");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
