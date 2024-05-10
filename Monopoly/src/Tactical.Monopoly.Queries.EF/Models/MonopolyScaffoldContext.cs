using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tactical.Monopoly.Queries.EF.Models;

public partial class MonopolyScaffoldContext : DbContext
{
    public MonopolyScaffoldContext()
    {
    }

    public MonopolyScaffoldContext(DbContextOptions<MonopolyScaffoldContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<BoardScore> BoardScores { get; set; }

    public virtual DbSet<Cell> Cells { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerId> PlayerIds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=MonopolyDB;user id=postgres; Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Board>(entity =>
        {
            entity.ToTable("Board");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<BoardScore>(entity =>
        {
            entity.ToTable("BoardScore");

            entity.HasIndex(e => e.BoardId, "IX_BoardScore_BoardId");

            entity.HasOne(d => d.Board).WithMany(p => p.BoardScores).HasForeignKey(d => d.BoardId);
        });

        modelBuilder.Entity<Cell>(entity =>
        {
            entity.ToTable("Cell");

            entity.HasIndex(e => e.BoardId, "IX_Cell_BoardId");

            entity.HasOne(d => d.Board).WithMany(p => p.Cells).HasForeignKey(d => d.BoardId);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PlayerId>(entity =>
        {
            entity.ToTable("PlayerId");

            entity.HasIndex(e => e.CellId, "IX_PlayerId_CellId");

            entity.HasIndex(e => e.Value, "IX_PlayerId_Value");

            entity.HasOne(d => d.Cell).WithMany(p => p.PlayerIds).HasForeignKey(d => d.CellId);

            entity.HasOne(d => d.ValueNavigation).WithMany(p => p.PlayerIds).HasForeignKey(d => d.Value);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
