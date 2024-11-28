using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invoice_system_backend.Migrations
{
    /// <inheritdoc />
    public partial class EditedGSTCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GST",
                table: "Invoices",
                newName: "GST_Number");

            migrationBuilder.RenameColumn(
                name: "GST",
                table: "Companies",
                newName: "GST_Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GST_Number",
                table: "Invoices",
                newName: "GST");

            migrationBuilder.RenameColumn(
                name: "GST_Number",
                table: "Companies",
                newName: "GST");
        }
    }
}
