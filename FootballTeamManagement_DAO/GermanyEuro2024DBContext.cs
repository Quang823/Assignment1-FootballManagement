﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FootballTeamManagement_BusinessObject.Models;

public partial class GermanyEuro2024DBContext : DbContext
{
    public GermanyEuro2024DBContext()
    {
    }

    public GermanyEuro2024DBContext(DbContextOptions<GermanyEuro2024DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FootballPlayer> FootballPlayer { get; set; }

    public virtual DbSet<FootballTeam> FootballTeam { get; set; }

    public virtual DbSet<Uefaaccount> Uefaaccount { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FootballPlayer>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Football__4A4E74A8B7F00159");

            entity.Property(e => e.PlayerId)
                .HasMaxLength(30)
                .HasColumnName("PlayerID");
            entity.Property(e => e.Achievements)
                .IsRequired()
                .HasMaxLength(250);
            entity.Property(e => e.Award)
                .IsRequired()
                .HasMaxLength(250);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.FootballTeamId)
                .HasMaxLength(30)
                .HasColumnName("FootballTeamID");
            entity.Property(e => e.OriginCountry)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.PlayerName)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.FootballTeam).WithMany(p => p.FootballPlayer)
                .HasForeignKey(d => d.FootballTeamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FootballP__Footb__3C69FB99");
        });

        modelBuilder.Entity<FootballTeam>(entity =>
        {
            entity.HasKey(e => e.FootballTeamId).HasName("PK__Football__B287F27B5436A098");

            entity.Property(e => e.FootballTeamId)
                .HasMaxLength(30)
                .HasColumnName("FootballTeamID");
            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ManagerName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.TeamTitle)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Uefaaccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__UEFAAcco__349DA5861115E45D");

            entity.ToTable("UEFAAccount");

            entity.HasIndex(e => e.AccountEmail, "UQ__UEFAAcco__FC770D33E5560109").IsUnique();

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
            entity.Property(e => e.AccountDescription)
                .IsRequired()
                .HasMaxLength(240);
            entity.Property(e => e.AccountEmail).HasMaxLength(80);
            entity.Property(e => e.AccountPassword)
                .IsRequired()
                .HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}