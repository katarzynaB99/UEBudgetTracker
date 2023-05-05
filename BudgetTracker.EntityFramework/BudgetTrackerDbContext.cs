using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.EntityFramework
{
    public class BudgetTrackerDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public BudgetTrackerDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(account =>
            {
                account.HasIndex(e => e.Name).IsUnique();
                account.Property(e => e.Id).ValueGeneratedOnAdd();
                account.Property(e => e.CreationDate).ValueGeneratedOnAdd();
                account.Property(e => e.Name).IsRequired();

                account.HasOne(e => e.User)
                    .WithMany(e => e.Accounts)
                    .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Bill>(bill =>
            {
                bill.Property(e => e.Id).ValueGeneratedOnAdd();
                bill.Property(e => e.CreationDate).ValueGeneratedOnAdd();
                bill.Property(e => e.DueDate).IsRequired();
                bill.Property(e => e.Name).IsRequired();

                bill.HasOne(e => e.Category)
                    .WithMany(e => e.Bills);
                bill.HasOne(e => e.User)
                    .WithMany(e => e.Bills);
            });
            
            modelBuilder.Entity<Category>(category =>
            {
                category.Property(e => e.Id).ValueGeneratedOnAdd();
                category.Property(e => e.CreationDate).ValueGeneratedOnAdd();
                category.Property(e => e.Name).IsRequired();

                category.HasOne(e => e.TransactionType)
                    .WithMany(e => e.Categories);
                category.HasOne(e => e.User)
                    .WithMany(e => e.Categories);
            });
            
            modelBuilder.Entity<Transaction>(transaction =>
            {
                transaction.Property(e => e.Id).ValueGeneratedOnAdd();
                transaction.Property(e => e.CreationDate).ValueGeneratedOnAdd();
                transaction.Property(e => e.TransactionDate).IsRequired();

                transaction.HasOne(e => e.Account)
                    .WithMany(e => e.Transactions);
                transaction.HasOne(e => e.Category)
                    .WithMany(e => e.Transactions);
                transaction.HasOne(e => e.TransactionType)
                    .WithMany(e => e.Transactions);
            });
            
            modelBuilder.Entity<TransactionType>(transactionType =>
            {
                transactionType.Property(e => e.Id).ValueGeneratedOnAdd();
                transactionType.Property(e => e.Name).IsRequired();
            });
            
            modelBuilder.Entity<User>(user =>
            {
                user.HasIndex(e => e.Username).IsUnique();
                user.Property(e => e.Id).ValueGeneratedOnAdd();
                user.Property(e => e.CreationDate).ValueGeneratedOnAdd();
                user.Property(e => e.Username).IsRequired();
                user.Property(e => e.Password).IsRequired();
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
