using System;
using System.Collections.Generic;
using DCI_HELPDESK_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DCI_HELPDESK_API.Contexts;

public partial class DBSCM : DbContext
{
    public DBSCM()
    {
    }

    public DBSCM(DbContextOptions<DBSCM> options)
        : base(options)
    {
    }

    public virtual DbSet<HelpdeskDict> HelpdeskDicts { get; set; }

    public virtual DbSet<HelpdeskJob> HelpdeskJobs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.226.86;Database=dbSCM;TrustServerCertificate=True;uid=sa;password=decjapan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CI_AS");

        modelBuilder.Entity<HelpdeskDict>(entity =>
        {
            entity.HasKey(e => new { e.HdId, e.HdCategory, e.HdCode });

            entity.ToTable("HELPDESK_DICT");

            entity.Property(e => e.HdId)
                .ValueGeneratedOnAdd()
                .HasColumnName("HD_ID");
            entity.Property(e => e.HdCategory)
                .HasMaxLength(20)
                .HasColumnName("HD_CATEGORY");
            entity.Property(e => e.HdCode)
                .HasMaxLength(50)
                .HasColumnName("HD_CODE");
            entity.Property(e => e.HdActive)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("1 = ใช้งาน, 0 = ไม่ใช้งาน")
                .HasColumnName("HD_ACTIVE");
            entity.Property(e => e.HdCreateBy)
                .HasMaxLength(20)
                .HasColumnName("HD_CREATE_BY");
            entity.Property(e => e.HdCreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("HD_CREATE_DATE");
            entity.Property(e => e.HdDesc)
                .HasMaxLength(50)
                .HasColumnName("HD_DESC");
            entity.Property(e => e.HdIndex).HasColumnName("HD_INDEX");
            entity.Property(e => e.HdRatio)
                .HasDefaultValueSql("((1))")
                .HasColumnName("HD_RATIO");
            entity.Property(e => e.HdRef)
                .HasMaxLength(50)
                .HasColumnName("HD_REF");
            entity.Property(e => e.HdTitle)
                .HasMaxLength(50)
                .HasColumnName("HD_TITLE");
            entity.Property(e => e.HdUpdateBy)
                .HasMaxLength(20)
                .HasColumnName("HD_UPDATE_BY");
            entity.Property(e => e.HdUpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("HD_UPDATE_DATE");
        });

        modelBuilder.Entity<HelpdeskJob>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HELPDESK_JOB");

            entity.Property(e => e.HdCode)
                .HasMaxLength(20)
                .HasColumnName("HD_CODE");
            entity.Property(e => e.JobCloseDate)
                .HasColumnType("datetime")
                .HasColumnName("JOB_CLOSE_DATE");
            entity.Property(e => e.JobFac).HasColumnName("JOB_FAC");
            entity.Property(e => e.JobHolder)
                .HasMaxLength(5)
                .HasColumnName("JOB_HOLDER");
            entity.Property(e => e.JobId)
                .ValueGeneratedOnAdd()
                .HasColumnName("JOB_ID");
            entity.Property(e => e.JobLocation)
                .HasMaxLength(20)
                .HasColumnName("JOB_LOCATION");
            entity.Property(e => e.JobReceivedBy)
                .HasMaxLength(5)
                .HasColumnName("JOB_RECEIVED_BY");
            entity.Property(e => e.JobReceivedDate)
                .HasColumnType("datetime")
                .HasColumnName("JOB_RECEIVED_DATE");
            entity.Property(e => e.JobReqBy)
                .HasMaxLength(5)
                .HasColumnName("JOB_REQ_BY");
            entity.Property(e => e.JobReqDate)
                .HasColumnType("datetime")
                .HasColumnName("JOB_REQ_DATE");
            entity.Property(e => e.JobStatus)
                .HasMaxLength(20)
                .HasDefaultValueSql("(N'REQUEST')")
                .HasColumnName("JOB_STATUS");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(5)
                .HasColumnName("UPDATE_BY");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
