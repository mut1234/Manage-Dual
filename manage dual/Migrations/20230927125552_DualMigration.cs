using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace manage_dual.Migrations
{
    /// <inheritdoc />
    public partial class DualMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    clientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientDateAddedToSystem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.clientId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDateAddedToSystem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Client_Item_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_client_Client_Item_Id",
                        column: x => x.Client_Item_Id,
                        principalTable: "client",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAmount = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemainingPayments = table.Column<int>(type: "int", nullable: false),
                    Payment_Client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_client_Payment_Client_id",
                        column: x => x.Payment_Client_id,
                        principalTable: "client",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "client",
                columns: new[] { "clientId", "Address", "City", "ClientDateAddedToSystem", "Email", "Name", "PhoneNumber", "PostalCode" },
                values: new object[,]
                {
                    { 1, "St 124", "Amman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmad3323@gmail.com", "Ahmad", "079649321763", "342667" },
                    { 2, "St 1324", "Amman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali3323@gmail.com", "Ali", "07964421763", "134667" },
                    { 3, "St 1214", "Amman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yaser4323@gmail.com", "Yaser", "079649351763", "142667" },
                    { 4, "St 1244", "Amman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "khaled4323@gmail.com", "khaled", "079649521763", "242667" },
                    { 5, "St 1224", "Amman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mhmod4323@gmail.com", "mhmod", "079649321763", "352667" },
                    { 6, "St 1264", "Amman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mustafa4323@gmail.com", "mustafa", "079149321762", "842667" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_Client_Item_Id",
                table: "Item",
                column: "Client_Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Payment_Client_id",
                table: "Payments",
                column: "Payment_Client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
