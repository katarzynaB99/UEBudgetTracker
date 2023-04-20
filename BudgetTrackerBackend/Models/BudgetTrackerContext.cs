using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BudgetTrackerBackend.Models
{
    public partial class BudgetTrackerContext : DbContext
    {
        public BudgetTrackerContext()
        {
        }

        public BudgetTrackerContext(DbContextOptions<BudgetTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.StartingAmount).HasColumnType("DOUBLE");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("DOUBLE");

                entity.Property(e => e.DueDate).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("DOUBLE");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TypeId);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
