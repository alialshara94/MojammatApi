using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojammatApi.Migrations
{
    /// <inheritdoc />
    public partial class editServicesStatusAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "services",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "services");
        }
    }
}
