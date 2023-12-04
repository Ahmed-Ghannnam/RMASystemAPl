using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMASystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditTablesName_LoyaltySetupHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RetailCustomerPointsStatements",
                table: "RetailCustomerPointsStatements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoyaltySetupHeaders",
                table: "LoyaltySetupHeaders");

            migrationBuilder.RenameTable(
                name: "RetailCustomerPointsStatements",
                newName: "RetailCustomerPointsStatement");

            migrationBuilder.RenameTable(
                name: "LoyaltySetupHeaders",
                newName: "LoyaltySetupHeader");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RetailCustomerPointsStatement",
                table: "RetailCustomerPointsStatement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoyaltySetupHeader",
                table: "LoyaltySetupHeader",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RetailCustomerPointsStatement",
                table: "RetailCustomerPointsStatement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoyaltySetupHeader",
                table: "LoyaltySetupHeader");

            migrationBuilder.RenameTable(
                name: "RetailCustomerPointsStatement",
                newName: "RetailCustomerPointsStatements");

            migrationBuilder.RenameTable(
                name: "LoyaltySetupHeader",
                newName: "LoyaltySetupHeaders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RetailCustomerPointsStatements",
                table: "RetailCustomerPointsStatements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoyaltySetupHeaders",
                table: "LoyaltySetupHeaders",
                column: "Id");
        }
    }
}
