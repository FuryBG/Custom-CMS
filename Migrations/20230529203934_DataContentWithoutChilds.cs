using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DataContentWithoutChilds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataContent_DataContent_DataContentId1",
                table: "DataContent");

            migrationBuilder.DropIndex(
                name: "IX_DataContent_DataContentId1",
                table: "DataContent");

            migrationBuilder.DropColumn(
                name: "DataContentId1",
                table: "DataContent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DataContentId1",
                table: "DataContent",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataContent_DataContentId1",
                table: "DataContent",
                column: "DataContentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DataContent_DataContent_DataContentId1",
                table: "DataContent",
                column: "DataContentId1",
                principalTable: "DataContent",
                principalColumn: "DataContentId");
        }
    }
}
