using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketWEB.Migrations
{
    /// <inheritdoc />
    public partial class AddProvidersAndPayModes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PayModes",
                newName: "MetodoPago");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetodoPago",
                table: "PayModes",
                newName: "Name");
        }
    }
}
