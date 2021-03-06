﻿using Microsoft.EntityFrameworkCore;
using TradingApplication.Domain.Models;

namespace TradingApplication.EntityFramework
{
   public class TradingApplicationDbContext : DbContext
   {
      public DbSet<User> Users { get; set; }

      public DbSet<Account> Accounts { get; set; }

      public DbSet<AssetTransaction> AssetTransactions { get; set; }

      public TradingApplicationDbContext(DbContextOptions options) : base(options)
      {

      }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Asset);
         base.OnModelCreating(modelBuilder);
      }
   }
}
