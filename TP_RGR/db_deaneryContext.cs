using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TP_RGR
{
    public partial class Db_deaneryContext : DbContext
    {
        public Db_deaneryContext()
        {
        }

        public Db_deaneryContext(DbContextOptions<Db_deaneryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Lecturer> Lecturers { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=root;database=db_deanery", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.Idfaculty)
                    .HasName("PRIMARY");

                entity.ToTable("faculty");

                entity.HasIndex(e => e.Name, "Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idfaculty).HasColumnName("IDfaculty");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_name'");

                entity.Property(e => e.Status).HasMaxLength(45);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.Idgroups)
                    .HasName("PRIMARY");

                entity.ToTable("groups");

                entity.HasIndex(e => e.FacultyId, "FacultyID_idx");

                entity.HasIndex(e => e.Name, "Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idgroups).HasColumnName("IDgroups");

                entity.Property(e => e.DateOfFormation).HasDefaultValueSql("'2000-01-01'");

                entity.Property(e => e.FacultyId)
                    .HasColumnName("FacultyID")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_group'");

                entity.Property(e => e.SpecialityCode).HasDefaultValueSql("'1'");

                entity.Property(e => e.Status).HasMaxLength(45);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_Faculty");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.HasKey(e => e.Idlecturer)
                    .HasName("PRIMARY");

                entity.ToTable("lecturer");

                entity.Property(e => e.Idlecturer).HasColumnName("IDlecturer");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_name'");

                entity.Property(e => e.Patronmyc)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_patronmyc'");

                entity.Property(e => e.Status).HasMaxLength(45);

                entity.Property(e => e.SurName)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_surname'");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => e.Idmarks)
                    .HasName("PRIMARY");

                entity.ToTable("marks");

                entity.HasIndex(e => e.RecordBook, "FK_Marks_Students_idx");

                entity.HasIndex(e => e.Idsubject, "FK_Marks_Subjects_idx");

                entity.Property(e => e.Idmarks).HasColumnName("IDmarks");

                entity.Property(e => e.Idsubject)
                    .HasColumnName("IDsubject")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Mark1)
                    .HasColumnName("Mark")
                    .HasDefaultValueSql("'5'");

                entity.Property(e => e.RecordBook).HasDefaultValueSql("'1'");

                entity.Property(e => e.Status).HasMaxLength(45);

                entity.HasOne(d => d.IdsubjectNavigation)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.Idsubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marks_Subjects");

                entity.HasOne(d => d.RecordBookNavigation)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.RecordBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marks_Students");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.RecordBook)
                    .HasName("PRIMARY");

                entity.ToTable("students");

                entity.HasIndex(e => e.GroupId, "FK_Students_Groups_idx");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .HasDefaultValueSql("'test_address'");

                entity.Property(e => e.GroupId)
                    .HasColumnName("GroupID")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_name'");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_patronymic'");

                entity.Property(e => e.Status).HasMaxLength(45);

                entity.Property(e => e.SurName)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_surname'");

                entity.Property(e => e.TelNumber)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_number'");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Groups");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Idsubjects)
                    .HasName("PRIMARY");

                entity.ToTable("subjects");

                entity.HasIndex(e => e.Idlecturer, "FK_Subject_Lecturer_idx");

                entity.Property(e => e.Idsubjects).HasColumnName("IDsubjects");

                entity.Property(e => e.Idlecturer)
                    .HasColumnName("IDlecturer")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'test_name'");

                entity.Property(e => e.Status).HasMaxLength(45);

                entity.HasOne(d => d.IdlecturerNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.Idlecturer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Lecturer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
