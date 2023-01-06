using System;
using System.Collections.Generic;
using IssueReporting.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueReporting.DataAccess.Configuration;

public partial class IssueReportingContext : DbContext
{
    public IssueReportingContext()
    {
    }

    public IssueReportingContext(DbContextOptions<IssueReportingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationMaster> ApplicationMasters { get; set; }

    public virtual DbSet<IssueDetail> IssueDetails { get; set; }

    public virtual DbSet<IssueMaster> IssueMasters { get; set; }

    public virtual DbSet<TypeMaster> TypeMasters { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AAD-PF2B2JDD;DataBase=issue_reporting;Trusted_Connection=True;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationMaster>(entity =>
        {
            entity.HasKey(e => e.ApplicationId);

            entity.ToTable("APPLICATION_MASTER");

            entity.Property(e => e.ApplicationId).HasColumnName("APPLICATION_ID");
            entity.Property(e => e.ApplcationName)
                .HasMaxLength(255)
                .HasColumnName("APPLCATION_NAME");
            entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

            entity.HasOne(d => d.Type).WithMany(p => p.ApplicationMasters)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APPLICATION_MASTER_TYPE_MASTER");
        });

        modelBuilder.Entity<IssueDetail>(entity =>
        {
            entity.HasKey(e => e.TicketId);

            entity.ToTable("ISSUE_DETAILS");

            entity.Property(e => e.TicketId).HasColumnName("TICKET_ID");
            entity.Property(e => e.ApplicationId).HasColumnName("APPLICATION_ID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            entity.Property(e => e.IssueDetails).HasColumnName("ISSUE_DETAILS");
            entity.Property(e => e.IssueId).HasColumnName("ISSUE_ID");
            entity.Property(e => e.LastUpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("LAST_UPDATED_AT");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

            entity.HasOne(d => d.Application).WithMany(p => p.IssueDetails)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ISSUE_DETAILS_APPLICATION_MASTER");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IssueDetails)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ISSUE_DETAILS_USER_MASTER");

            entity.HasOne(d => d.Issue).WithMany(p => p.IssueDetails)
                .HasForeignKey(d => d.IssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ISSUE_DETAILS_ISSUE_MASTER");

            entity.HasOne(d => d.Type).WithMany(p => p.IssueDetails)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ISSUE_DETAILS_TYPE_MASTER");
        });

        modelBuilder.Entity<IssueMaster>(entity =>
        {
            entity.HasKey(e => e.IssueId);

            entity.ToTable("ISSUE_MASTER");

            entity.Property(e => e.IssueId).HasColumnName("ISSUE_ID");
            entity.Property(e => e.ApplicationId).HasColumnName("APPLICATION_ID");
            entity.Property(e => e.IssueName)
                .HasMaxLength(50)
                .HasColumnName("ISSUE_NAME");

            entity.HasOne(d => d.Application).WithMany(p => p.IssueMasters)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ISSUE_MASTER_APPLICATION_MASTER");
        });

        modelBuilder.Entity<TypeMaster>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("TYPE_MASTER");

            entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("TYPE_NAME");
        });

        modelBuilder.Entity<UserMaster>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("USER_MASTER");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("USER_ID");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Role).HasColumnName("ROLE");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("USER_EMAIL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
