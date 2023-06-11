using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Stallions.HotelBooking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class hotel_Entities_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("19ca1e06-2123-489d-96f6-5f1652589159"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ba53e28e-c688-43c5-abcc-8c44c1b0b234"));

            migrationBuilder.CreateTable(
                name: "BookingStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomBooking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomBooking_BookingStatus_BookingStatusId",
                        column: x => x.BookingStatusId,
                        principalTable: "BookingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomBooking_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookingStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8c623913-21ce-4aa4-9221-7494e4822734"), "Accepted" },
                    { new Guid("a61881cf-8aae-413a-bc61-69f54195715d"), "Rejected" },
                    { new Guid("dc0b6637-8c98-4015-884c-7247d410f7e7"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("08333331-529f-48ec-a800-c2d12fc2a102"), "2a597d29-0edd-4d2b-b005-f405c7a287c8", "Customer", "customer" },
                    { new Guid("ec6c5d9c-7fc5-4751-8ee0-d56b0f028f31"), "20462273-7790-49e8-ba62-58ab6efb51a8", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("27796872-762d-414d-b6cc-8ca0ea210819"), "Single" },
                    { new Guid("e5364966-8a8c-4a49-99c7-29ccc45a3f66"), "Double" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_BookingStatusId",
                table: "RoomBooking",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_CustomerId",
                table: "RoomBooking",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_RoomId",
                table: "RoomBooking",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomBooking");

            migrationBuilder.DropTable(
                name: "BookingStatus");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("08333331-529f-48ec-a800-c2d12fc2a102"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ec6c5d9c-7fc5-4751-8ee0-d56b0f028f31"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("19ca1e06-2123-489d-96f6-5f1652589159"), "04097016-d945-4048-9e36-1f36718c3768", "Admin", "admin" },
                    { new Guid("ba53e28e-c688-43c5-abcc-8c44c1b0b234"), "3ea27f9a-8f49-44da-9c8f-e22507250fd2", "Customer", "customer" }
                });
        }
    }
}
