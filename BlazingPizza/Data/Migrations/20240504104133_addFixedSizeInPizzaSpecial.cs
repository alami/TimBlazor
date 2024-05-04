using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingPizza.Data.Migrations
{
    /// <inheritdoc />
    public partial class addFixedSizeInPizzaSpecial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FixedSize",
                table: "Specials",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FixedSize",
                table: "Specials");
        }
    }
}
