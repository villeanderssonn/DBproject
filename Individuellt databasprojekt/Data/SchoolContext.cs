
using Microsoft.EntityFrameworkCore;
using Individuellt_databasprojekt.Models;

namespace Individuellt_databasprojekt.Data
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Personnel> Personnel { get; set; } = null!;
        public virtual DbSet<Models.Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-EPSSJ94\\MSSQLSERVER01;Database=Highschool;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherCourseSalary).HasColumnType("money");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Grade1)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("Grade");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Grades__CourseID__4222D4EF");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Grades__StudentI__412EB0B6");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Grades__TeacherI__4316F928");
            });

            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Models.Student>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property<string>(e => e.Class)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property<string>(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property<string>(e => e.PersonalNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
