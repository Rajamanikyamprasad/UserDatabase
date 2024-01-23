using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserDatabase.Api.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class Secondadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    addressid = table.Column<Guid>(name: "address_id", type: "uniqueidentifier", nullable: false),
                    customername = table.Column<string>(name: "customer_name", type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "int", nullable: false),
                    streetaddress = table.Column<string>(name: "street_address", type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stateprovince = table.Column<string>(name: "state_province", type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postalcode = table.Column<string>(name: "postal_code", type: "int", nullable: false),
                    addresstype = table.Column<string>(name: "address_type", type: "nvarchar(max)", nullable: false),
                    customerid = table.Column<Guid>(name: "customer_id", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.addressid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
