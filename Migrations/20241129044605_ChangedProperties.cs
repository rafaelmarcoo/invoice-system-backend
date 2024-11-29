using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invoice_system_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_clientCompany_Code",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "clientCompany_Code",
                table: "Invoices",
                newName: "clientCompanyCode");

            migrationBuilder.RenameColumn(
                name: "Company_Code",
                table: "Invoices",
                newName: "CompanyCode");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_clientCompany_Code",
                table: "Invoices",
                newName: "IX_Invoices_clientCompanyCode");

            migrationBuilder.RenameColumn(
                name: "GST_Number",
                table: "Companies",
                newName: "GstNumber");

            migrationBuilder.RenameColumn(
                name: "GST_Number",
                table: "Clients",
                newName: "GstNumber");

            migrationBuilder.RenameColumn(
                name: "Company_Code",
                table: "Clients",
                newName: "CompanyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_clientCompanyCode",
                table: "Invoices",
                column: "clientCompanyCode",
                principalTable: "Clients",
                principalColumn: "CompanyCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_clientCompanyCode",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "clientCompanyCode",
                table: "Invoices",
                newName: "clientCompany_Code");

            migrationBuilder.RenameColumn(
                name: "CompanyCode",
                table: "Invoices",
                newName: "Company_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_clientCompanyCode",
                table: "Invoices",
                newName: "IX_Invoices_clientCompany_Code");

            migrationBuilder.RenameColumn(
                name: "GstNumber",
                table: "Companies",
                newName: "GST_Number");

            migrationBuilder.RenameColumn(
                name: "GstNumber",
                table: "Clients",
                newName: "GST_Number");

            migrationBuilder.RenameColumn(
                name: "CompanyCode",
                table: "Clients",
                newName: "Company_Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_clientCompany_Code",
                table: "Invoices",
                column: "clientCompany_Code",
                principalTable: "Clients",
                principalColumn: "Company_Code");
        }
    }
}
