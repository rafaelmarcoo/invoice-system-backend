using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invoice_system_backend.Migrations
{
    /// <inheritdoc />
    public partial class CleintInvoiceFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_clientCompanyCode",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_clientCompanyCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CompanyCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "clientCompanyCode",
                table: "Invoices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                table: "Invoices",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "clientCompanyCode",
                table: "Invoices",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_clientCompanyCode",
                table: "Invoices",
                column: "clientCompanyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_clientCompanyCode",
                table: "Invoices",
                column: "clientCompanyCode",
                principalTable: "Clients",
                principalColumn: "CompanyCode");
        }
    }
}
