using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invoice_system_backend.Migrations
{
    /// <inheritdoc />
    public partial class RenamingInvoiceFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Invoices",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Date_Sent",
                table: "Invoices",
                newName: "DateSent");

            migrationBuilder.RenameColumn(
                name: "Date_Due",
                table: "Invoices",
                newName: "DateDue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Invoices",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "DateSent",
                table: "Invoices",
                newName: "Date_Sent");

            migrationBuilder.RenameColumn(
                name: "DateDue",
                table: "Invoices",
                newName: "Date_Due");
        }
    }
}
