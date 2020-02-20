using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EFPlay
{
    public class PotterShopContext : DbContext
    {
        protected string connectionString;

        public PotterShopContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public PotterShopContext(string connString)
        {
            this.connectionString = connString;
        }

        public DbSet<Pots> Pots { get; set; }
        public DbSet<PotImages> PotImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // warning To protect potentially sensitive information in your connection string, you should move it out of source code.See http://go.microsoft.com/fwlink/?LinkId=723263 
            //            for guidance on storing connection strings.

            optionsBuilder.UseMySql(connectionString);
        }
    }
}
