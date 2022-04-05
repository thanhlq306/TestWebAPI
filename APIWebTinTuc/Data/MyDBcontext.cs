﻿using Microsoft.EntityFrameworkCore;

namespace APIWebTinTuc.Data
{
    public class MyDBcontext : DbContext
    {
        public MyDBcontext(DbContextOptions options): base(options) { }

        #region DbSet
        public DbSet<DataBaiViet> dataBaiViets { get; set; }
        public DbSet<LoaiBaiViet> dataLoais { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.HotTen).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            });
        }
    }
}
