using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invoice_system_backend.Migrations
{
    /// <inheritdoc />
    public partial class EditedCompanyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GST",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GST",
                table: "Companies");
        }
    }
}
