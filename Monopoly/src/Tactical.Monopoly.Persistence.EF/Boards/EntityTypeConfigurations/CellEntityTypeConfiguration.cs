using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Monopoly.Domain.Boards.Entities;

namespace Tactical.Monopoly.Persistence.EF.Boards.EntityTypeConfigurations
{
    internal class CellEntityTypeConfiguration : IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> builder)
        {
            builder.ToTable(nameof(Cell));
            builder.Property(p => p.Id);

            builder.OwnsMany(p => p.CellPlayerIds, a =>
            {
                a.Property(x => x.Value);
            });
        }
    }
}
