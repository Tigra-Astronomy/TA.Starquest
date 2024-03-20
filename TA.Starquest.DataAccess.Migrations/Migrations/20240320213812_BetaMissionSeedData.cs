using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TA.Starquest.DataAccess.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class BetaMissionSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2e1b3d3-f1cf-4c9b-b712-37502c6e9992",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Provisioned", "SecurityStamp" },
                values: new object[] { "e357f3a2-63ad-44ea-9290-467fc8bfc483", "AQAAAAIAAYagAAAAEO6a0s79dij4ghjPdc4Qdl6gGZ5/LbF7EtFLaEgX6KGtvfTEsxYNmE5xVxlYqFIJYw==", new DateTime(2024, 3, 20, 21, 38, 12, 318, DateTimeKind.Utc).AddTicks(3842), "7f757760-6739-42e8-8ee7-da9ef5cea804" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2e1b3d3-f1cf-4c9b-b712-37502c6e9992",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Provisioned", "SecurityStamp" },
                values: new object[] { "067e246f-dafc-4e27-967f-d9336b18829d", "AQAAAAIAAYagAAAAEAkVuWRo/405Tdw1FY6vBWMe9gnG9L4q5xv5Ps13yIUPRcoUvAFyyjSoQH5Ib3Zwqw==", new DateTime(2024, 3, 20, 21, 37, 20, 165, DateTimeKind.Utc).AddTicks(2402), "0072ed7f-180b-4a2a-8a28-60006a2196ce" });
        }
    }
}
