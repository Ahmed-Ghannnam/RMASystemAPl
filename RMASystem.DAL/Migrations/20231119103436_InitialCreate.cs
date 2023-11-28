using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMASystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIReceivedRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiType = table.Column<int>(type: "int", nullable: false),
                    ApiUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIReceivedRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetailCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameL1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameL2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaSerial = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastSalesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastSalesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpeningBalancePoints = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebitPoints = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditPoints = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentPointsBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplyDiscount = table.Column<bool>(type: "bit", nullable: false),
                    InsertUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityID = table.Column<int>(type: "int", nullable: false),
                    CardCode2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardCodeExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailCustomers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIReceivedRequests");

            migrationBuilder.DropTable(
                name: "RetailCustomers");
        }
    }
}
