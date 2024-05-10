using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Persistence.EF.Boards.EntityTypeConfigurations
{
    internal class CellPlayerIdEntityTypeConfiguration : IEntityTypeConfiguration<PlayerId>
    {
        public void Configure(EntityTypeBuilder<PlayerId> builder)
        {
            builder.ToTable(nameof(PlayerId));
            //builder.HasKey(p => p.Id);
            //builder.Property(p => p.Id);

            //builder.Property(p => p.CellId);

        }
    }
}
