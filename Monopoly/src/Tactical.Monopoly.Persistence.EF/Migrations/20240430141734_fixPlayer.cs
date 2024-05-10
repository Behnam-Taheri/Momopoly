using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactical.Monopoly.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class fixPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Player");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Player",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Player");

            migrationBuilder.AddColumn<Guid>(
                name: "BoardId",
                table: "Player",
                type: "uuid",
                nullable: true);
        }
    }
}
