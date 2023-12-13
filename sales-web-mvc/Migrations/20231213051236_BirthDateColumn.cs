using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sales_web_mvc.Migrations
{
    /// <inheritdoc />
    public partial class BirthDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BithDate",
                table: "Seller",
                newName: "BirthDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Seller",
                newName: "BithDate");
        }
    }
}
