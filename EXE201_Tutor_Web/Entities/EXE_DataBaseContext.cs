using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EXE201_Tutor_Web.Entities
{
    public partial class EXE_DataBaseContext : DbContext
    {
        public EXE_DataBaseContext()
        {
        }

        public EXE_DataBaseContext(DbContextOptions<EXE_DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coursera> Courseras { get; set; } = null!;
        public virtual DbSet<Courseradetail> Courseradetails { get; set; } = null!;
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<Mooc> Moocs { get; set; } = null!;
        public virtual DbSet<Moocdetail> Moocdetails { get; set; } = null!;
        public virtual DbSet<Oncoursedetail> Oncoursedetails { get; set; } = null!;
        public virtual DbSet<Oncoursera> Oncourseras { get; set; } = null!;
        public virtual DbSet<Onmooc> Onmoocs { get; set; } = null!;
        public virtual DbSet<Onmoocdetail> Onmoocdetails { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=103.195.236.140;port=3306;database=EXE_DataBase;uid=testuser;pwd=tT123412345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Coursera>(entity =>
            {
                entity.ToTable("coursera");

                entity.HasIndex(e => e.TeacherId, "IX_Coursera_TeacherId");

                entity.Property(e => e.EndDate).HasMaxLength(6);

                entity.Property(e => e.StartDate).HasMaxLength(6);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Courseras)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Coursera_Teacher_TeacherId");
            });

            modelBuilder.Entity<Courseradetail>(entity =>
            {
                entity.ToTable("courseradetail");

                entity.HasIndex(e => e.CourseraId, "IX_CourseraDetail_CourseraId");

                entity.Property(e => e.Date).HasMaxLength(6);

                entity.HasOne(d => d.Coursera)
                    .WithMany(p => p.Courseradetails)
                    .HasForeignKey(d => d.CourseraId)
                    .HasConstraintName("FK_CourseraDetail_Coursera_CourseraId");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Mooc>(entity =>
            {
                entity.ToTable("mooc");

                entity.HasIndex(e => e.CourseraDetailId, "IX_Mooc_CourseraDetailId");

                entity.Property(e => e.Date).HasMaxLength(6);

                entity.HasOne(d => d.CourseraDetail)
                    .WithMany(p => p.Moocs)
                    .HasForeignKey(d => d.CourseraDetailId)
                    .HasConstraintName("FK_Mooc_CourseraDetail_CourseraDetailId");
            });

            modelBuilder.Entity<Moocdetail>(entity =>
            {
                entity.ToTable("moocdetail");

                entity.HasIndex(e => e.MoocId, "IX_MoocDetail_MoocId");

                entity.Property(e => e.Date).HasMaxLength(6);

                entity.HasOne(d => d.Mooc)
                    .WithMany(p => p.Moocdetails)
                    .HasForeignKey(d => d.MoocId)
                    .HasConstraintName("FK_MoocDetail_Mooc_MoocId");
            });

            modelBuilder.Entity<Oncoursedetail>(entity =>
            {
                entity.ToTable("oncoursedetail");

                entity.HasIndex(e => e.CourseraDetailId, "IX_OnCourseDetail_CourseraDetailId");

                entity.HasIndex(e => e.OnCourseId, "IX_OnCourseDetail_OnCourseId");

                entity.Property(e => e.Date).HasMaxLength(6);

                entity.HasOne(d => d.CourseraDetail)
                    .WithMany(p => p.Oncoursedetails)
                    .HasForeignKey(d => d.CourseraDetailId)
                    .HasConstraintName("FK_OnCourseDetail_CourseraDetail_CourseraDetailId");

                entity.HasOne(d => d.OnCourse)
                    .WithMany(p => p.Oncoursedetails)
                    .HasForeignKey(d => d.OnCourseId)
                    .HasConstraintName("FK_OnCourseDetail_OnCoursera_OnCourseId");
            });

            modelBuilder.Entity<Oncoursera>(entity =>
            {
                entity.HasKey(e => e.OnCourseId)
                    .HasName("PRIMARY");

                entity.ToTable("oncoursera");

                entity.HasIndex(e => e.CourseraId, "IX_OnCoursera_CourseraId");

                entity.HasIndex(e => e.StudentId, "IX_OnCoursera_StudentId");

                entity.Property(e => e.Date).HasMaxLength(6);

                entity.HasOne(d => d.Coursera)
                    .WithMany(p => p.Oncourseras)
                    .HasForeignKey(d => d.CourseraId)
                    .HasConstraintName("FK_OnCoursera_Coursera_CourseraId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Oncourseras)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_OnCoursera_Student_StudentId");
            });

            modelBuilder.Entity<Onmooc>(entity =>
            {
                entity.ToTable("onmooc");

                entity.HasIndex(e => e.MoocId, "IX_OnMooc_MoocId");

                entity.HasIndex(e => e.OnCourseDetailId, "IX_OnMooc_OnCourseDetailId");

                entity.Property(e => e.DateSuccess).HasMaxLength(6);

                entity.HasOne(d => d.Mooc)
                    .WithMany(p => p.Onmoocs)
                    .HasForeignKey(d => d.MoocId)
                    .HasConstraintName("FK_OnMooc_Mooc_MoocId");

                entity.HasOne(d => d.OnCourseDetail)
                    .WithMany(p => p.Onmoocs)
                    .HasForeignKey(d => d.OnCourseDetailId)
                    .HasConstraintName("FK_OnMooc_OnCourseDetail_OnCourseDetailId");
            });

            modelBuilder.Entity<Onmoocdetail>(entity =>
            {
                entity.ToTable("onmoocdetail");

                entity.HasIndex(e => e.MoocDetailId, "IX_OnMoocDetail_MoocDetailId");

                entity.HasIndex(e => e.OnMoocId, "IX_OnMoocDetail_OnMoocId");

                entity.HasOne(d => d.MoocDetail)
                    .WithMany(p => p.Onmoocdetails)
                    .HasForeignKey(d => d.MoocDetailId)
                    .HasConstraintName("FK_OnMoocDetail_MoocDetail_MoocDetailId");

                entity.HasOne(d => d.OnMooc)
                    .WithMany(p => p.Onmoocdetails)
                    .HasForeignKey(d => d.OnMoocId)
                    .HasConstraintName("FK_OnMoocDetail_OnMooc_OnMoocId");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
