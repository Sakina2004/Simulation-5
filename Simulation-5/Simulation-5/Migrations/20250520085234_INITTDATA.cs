using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simulation_5.Migrations
{
    /// <inheritdoc />
    public partial class INITTDATA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Positions",
                newName: "fullname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "Positions",
                newName: "Name");
        }
    }
}
