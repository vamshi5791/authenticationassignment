using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DotNetCoreDemo.Models.DB
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("DATA SOURCE=GOVINDHUV\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book");

                entity.Property(e => e.Author)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Edition)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Shelf)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employee");

                entity.Property(e => e.Contact)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Possword)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftTime)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("student");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Sname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sname");

                entity.Property(e => e.Sno).HasColumnName("sno");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
