using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invoice_system_backend.Migrations
{
    /// <inheritdoc />
    public partial class fixinv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "InvoiceItems",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InvoiceItems",
                newName: "ItemId");
        }
    }
}
