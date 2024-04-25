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
            entity.HasKey(e => new { e.DictId, e.DictCategory, e.DictCode });

            entity.ToTable("HELPDESK_DICT");

            entity.Property(e => e.DictId)
                .ValueGeneratedOnAdd()
                .HasColumnName("DICT_ID");
            entity.Property(e => e.DictCategory)
                .HasMaxLength(20)
                .HasColumnName("DICT_CATEGORY");
            entity.Property(e => e.DictCode)
                .HasMaxLength(50)
                .HasColumnName("DICT_CODE");
            entity.Property(e => e.DictActive)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("1 = ใช้งาน, 0 = ไม่ใช้งาน")
                .HasColumnName("DICT_ACTIVE");
            entity.Property(e => e.DictCreateBy)
                .HasMaxLength(20)
                .HasColumnName("DICT_CREATE_BY");
            entity.Property(e => e.DictCreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DICT_CREATE_DATE");
            entity.Property(e => e.DictDesc)
                .HasMaxLength(50)
                .HasColumnName("DICT_DESC");
            entity.Property(e => e.DictIndex).HasColumnName("DICT_INDEX");
            entity.Property(e => e.DictRatio)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DICT_RATIO");
            entity.Property(e => e.DictRef)
                .HasMaxLength(50)
                .HasColumnName("DICT_REF");
            entity.Property(e => e.DictTitle)
                .HasMaxLength(50)
                .HasColumnName("DICT_TITLE");
            entity.Property(e => e.DictUpdateBy)
                .HasMaxLength(20)
                .HasColumnName("DICT_UPDATE_BY");
            entity.Property(e => e.DictUpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DICT_UPDATE_DATE");
        });

        modelBuilder.Entity<HelpdeskJob>(entity =>
        {
            entity.HasKey(e => e.JobId);

            entity.ToTable("HELPDESK_JOB");

            entity.Property(e => e.JobId).HasColumnName("JOB_ID");
            entity.Property(e => e.HdCode)
                .HasMaxLength(20)
                .HasColumnName("HD_CODE");
            entity.Property(e => e.JobAcceptBy)
                .HasMaxLength(5)
                .HasColumnName("JOB_ACCEPT_BY");
            entity.Property(e => e.JobAcceptDate)
                .HasColumnType("datetime")
                .HasColumnName("JOB_ACCEPT_DATE");
            entity.Property(e => e.JobDesc)
                .HasColumnType("text")
                .HasColumnName("JOB_DESC");
            entity.Property(e => e.JobFac).HasColumnName("JOB_FAC");
            entity.Property(e => e.JobFinishDate)
                .HasColumnType("datetime")
                .HasColumnName("JOB_FINISH_DATE");
            entity.Property(e => e.JobLocation)
                .HasMaxLength(20)
                .HasColumnName("JOB_LOCATION");
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
