using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedMainCmsEntitiesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Image",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    ArticlesArticleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriesCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => new { x.ArticlesArticleId, x.CategoriesCategoryId });
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Article_ArticlesArticleId",
                        column: x => x.ArticlesArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Category_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryImage",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagesImageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryImage", x => new { x.CategoriesCategoryId, x.ImagesImageId });
                    table.ForeignKey(
                        name: "FK_CategoryImage_Category_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryImage_Image_ImagesImageId",
                        column: x => x.ImagesImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ArticleId",
                table: "Image",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_CategoriesCategoryId",
                table: "ArticleCategory",
                column: "CategoriesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImage_ImagesImageId",
                table: "CategoryImage",
                column: "ImagesImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Article_ArticleId",
                table: "Image",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Article_ArticleId",
                table: "Image");

            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "CategoryImage");

            migrationBuilder.DropIndex(
                name: "IX_Image_ArticleId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Image");
        }
    }
}
