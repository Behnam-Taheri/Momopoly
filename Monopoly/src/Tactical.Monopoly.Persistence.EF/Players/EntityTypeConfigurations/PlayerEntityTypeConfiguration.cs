using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Monopoly.Domain.Boards.ValueObjects;
using Tactical.Monopoly.Domain.Players;

namespace Tactical.Monopoly.Persistence.EF.Players.EntityTypeConfigurations
{
    //internal class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    //{
    //    public void Configure(EntityTypeBuilder<Player> builder)
    //    {
    //        builder.ToTable(nameof(Player));
    //        builder.Property(p => p.Id).ValueGeneratedNever();


    //        builder.HasMany(typeof(PlayerId)).WithOne().HasForeignKey(nameof(PlayerId.Value));
    //    }
    //}
}
