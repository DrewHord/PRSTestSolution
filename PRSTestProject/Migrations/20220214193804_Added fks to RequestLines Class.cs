using Microsoft.EntityFrameworkCore.Migrations;

namespace PRSLibrary.Migrations
{
    public partial class AddedfkstoRequestLinesClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RequestLines_ProductId",
                table: "RequestLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLines_RequestId",
                table: "RequestLines",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLines_Products_ProductId",
                table: "RequestLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLines_Requests_RequestId",
                table: "RequestLines",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_Products_ProductId",
                table: "RequestLines");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_Requests_RequestId",
                table: "RequestLines");

            migrationBuilder.DropIndex(
                name: "IX_RequestLines_ProductId",
                table: "RequestLines");

            migrationBuilder.DropIndex(
                name: "IX_RequestLines_RequestId",
                table: "RequestLines");
        }
    }
}
