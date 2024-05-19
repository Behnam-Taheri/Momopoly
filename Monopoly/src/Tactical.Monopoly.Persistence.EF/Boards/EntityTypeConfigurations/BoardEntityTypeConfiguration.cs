using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Monopoly.Domain.Boards;
using Tactical.Monopoly.Domain.Boards.Entities;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Persistence.EF.Boards.EntityTypeConfigurations
{
    internal class BoardEntityTypeConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable(nameof(Board));
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.OwnsMany(x => x.Cells, o =>
            {
                o.ToTable(nameof(Cell));
                o.HasKey(x => x.Id);
                o.WithOwner().HasForeignKey(x => x.BoardId);
                o.Property(p => p.Name);
                o.Property(p => p.Position);
                o.Property(p => p.Group);
                o.Property(p => p.Price);
                o.Property(p => p.Buyable);
                o.Property(p => p.OwnerId);
                o.OwnsMany(x => x.PlayerIds, c =>
                {
                    c.Property(p => p.Value);
                });
            });

            builder.OwnsMany(x => x.BoardScores, o =>
            {
                o.ToTable(nameof(BoardScore));
                o.WithOwner().HasForeignKey(x => x.BoardId);
                o.Property(p => p.Score);
                o.Property(p => p.PlayerId);
                o.Property(p => p.BoardId);
            });
        }
    }
}
