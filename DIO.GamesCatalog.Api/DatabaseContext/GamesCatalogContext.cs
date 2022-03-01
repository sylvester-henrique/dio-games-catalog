using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DIO.GamesCatalog.Api.Entities;
using Microsoft.Extensions.Configuration;

namespace DIO.GamesCatalog.Api.DatabaseContext
{
    public partial class GamesCatalogContext : DbContext
    {
        private readonly string _connectionString;

        public GamesCatalogContext()
        {
        }

        public GamesCatalogContext(DbContextOptions<GamesCatalogContext> options, IConfiguration configuration)
            : base(options)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public virtual DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.Developer)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
