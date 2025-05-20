using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simulation_5.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "Positions",
                newName: "Fullname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Positions",
                newName: "fullname");
        }
    }
}
