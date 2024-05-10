using Microsoft.EntityFrameworkCore;
using Tactical.Monopoly.Queries.EF.Models;

namespace Tactical.Monopoly.Queries.EF
{
    public class RetrievalDbContext : MonopolyScaffoldContext
    {
        protected string ConnectionString;

        public RetrievalDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges() => throw new InvalidOperationException("You're not allowed to save any changes!");
        public override int SaveChanges(bool acceptAllChangesOnSuccess) => throw new InvalidOperationException("You're not allowed to save any changes!");

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        => throw new InvalidOperationException("You're not allowed to save any changes!");

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => throw new InvalidOperationException("You're not allowed to save any changes!");
    }
}
