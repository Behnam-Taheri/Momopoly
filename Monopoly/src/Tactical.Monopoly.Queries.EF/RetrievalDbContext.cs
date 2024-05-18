using Microsoft.EntityFrameworkCore;
using Tactical.Monopoly.Queries.EF.Models;

namespace Tactical.Monopoly.Queries.EF
{
    public class RetrievalDbContext : DbContext
    {
        public RetrievalDbContext(DbContextOptions<RetrievalDbContext> options) : base(options)
        {

        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<BoardScore> BoardScores { get; set; }
        public DbSet<PlayerId> PlayerIds { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Board>().ToTable(nameof(Board));
            modelBuilder.Entity<Cell>().ToTable(nameof(Cell));
            modelBuilder.Entity<BoardScore>().ToTable(nameof(BoardScore));
            modelBuilder.Entity<PlayerId>().ToTable(nameof(PlayerId));
            modelBuilder.Entity<Player>().ToTable(nameof(Player));
        }


        public override int SaveChanges() => throw new InvalidOperationException("You're not allowed to save any changes!");
        public override int SaveChanges(bool acceptAllChangesOnSuccess) => throw new InvalidOperationException("You're not allowed to save any changes!");

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        => throw new InvalidOperationException("You're not allowed to save any changes!");

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => throw new InvalidOperationException("You're not allowed to save any changes!");
    }
}
