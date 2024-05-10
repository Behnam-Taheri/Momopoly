using IdGen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Monopoly.Domain.Boards;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Persistence.EF.Boards.EntityTypeConfigurations
{
    internal class BoardEntityTypeConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable(nameof(Board));
            builder.Property(p => p.Id).ValueGeneratedNever();

            //builder.Ignore(p => p.PlayerIds);

            builder.HasMany(x => x.Cells).WithOne().HasForeignKey(x => x.BoardId);
            builder.HasMany(x => x.BoardScores).WithOne().HasForeignKey(x => x.BoardId);
        }
    }

    //internal class BoardScoresEntityTypeConfiguration : IEntityTypeConfiguration<BoardScore>
    //{
    //    public void Configure(EntityTypeBuilder<BoardScore> builder)
    //    {
    //        builder.ToTable(nameof(BoardScore));
    //        builder.Property(p => p.Id);
    //    }
    //}
}
