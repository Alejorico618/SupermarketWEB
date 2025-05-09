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
            migrationBuilder.CreateTable(
       name: "PayModes",
       columns: table => new
       {
           Id = table.Column<int>(type: "int", nullable: false)
               .Annotation("SqlServer:Identity", "1, 1"),
           Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
           IsActive = table.Column<bool>(type: "bit", nullable: false)
       },
       constraints: table =>
       {
           table.PrimaryKey("PK_PayModes", x => x.Id);
       });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "PayModes");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
