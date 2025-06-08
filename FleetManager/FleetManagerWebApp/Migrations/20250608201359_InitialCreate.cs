using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagerWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChassisId_Series = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ChassisId_Number = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    NumberOfPassengers = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
