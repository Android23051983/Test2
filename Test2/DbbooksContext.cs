using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Team_project.Model;

namespace Team_project;

public partial class DbbooksContext : DbContext
{
    public DbbooksContext()
    {
    }

    public DbbooksContext(DbContextOptions<DbbooksContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer($"Data Source={Environment.MachineName}\\SQLEXPRESS;Initial Catalog=DBBooks;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Authors__70DAFC147E5E5105");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C2274DA12BA7");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.AuthorFk).HasColumnName("Author_FK");
            entity.Property(e => e.CategoryFk).HasColumnName("Category_FK");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.AuthorFkNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorFk)
                .HasConstraintName("FK__Books__Author_FK__3B75D760");

            entity.HasOne(d => d.CategoryFkNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryFk)
                .HasConstraintName("FK__Books__Category___3C69FB99");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BD6888DBA");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
