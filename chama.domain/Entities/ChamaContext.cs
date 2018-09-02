using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace chama.domain.Entities
{
    public partial class ChamaContext : DbContext
    {
        public ChamaContext()
        {
        }

        public ChamaContext(DbContextOptions<ChamaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseStudent> CourseStudent { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<Queue> Queue { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LecturerId).HasColumnName("LecturerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COURSE__Lecturer__44FF419A");
            });

            modelBuilder.Entity<CourseStudent>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.StudentId });

                entity.ToTable("COURSE_STUDENT");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseStudent)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COURSE_ST__Cours__49C3F6B7");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CourseStudent)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COURSE_ST__Stude__4AB81AF0");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("LECTURER");

                entity.Property(e => e.LecturerId).HasColumnName("LecturerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Queue>(entity =>
            {
                entity.ToTable("QUEUE");

                entity.Property(e => e.QueueId)
                    .HasColumnName("QueueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Queue)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QUEUE__CourseID__4D94879B");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Queue)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QUEUE__StudentID__4E88ABD4");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
