using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Jobs;

public partial class JobPortalJobsContext : DbContext
{
    public JobPortalJobsContext()
    {
    }

    public JobPortalJobsContext(DbContextOptions<JobPortalJobsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JobPortal> JobPortals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-BLNTEBH7\\SQLEXPRESS;Database=JobPortalJobs;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobPortal>(entity =>
        {
            entity.HasKey(e => e.JobId);

            entity.ToTable("JobPortal");

            entity.Property(e => e.JobId)
                .ValueGeneratedNever()
                .HasColumnName("JobID");
            entity.Property(e => e.Dec).HasMaxLength(500);
            entity.Property(e => e.Skills).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
