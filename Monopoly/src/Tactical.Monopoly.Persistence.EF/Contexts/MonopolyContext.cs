using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactical.Monopoly.Domain.Boards;
using Tactical.Monopoly.Persistence.EF.Boards.EntityTypeConfigurations;

namespace Tactical.Monopoly.Persistence.EF.Contexts
{
    public class MonopolyContext : DbContext
    {
        public MonopolyContext(DbContextOptions<MonopolyContext> options) : base(options)
        {

        }

        public DbSet<Board> Boards {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoardEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
