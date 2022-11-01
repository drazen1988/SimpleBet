using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcesss.Migrations
{
    public partial class AddedPostLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReplyDateTime",
                table: "ChatReplies",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "ChatLikes",
                columns: table => new
                {
                    LikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikeDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLikes", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_ChatLikes_ChatPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "ChatPosts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7502b3fd-40fb-4a4a-ace8-647270657934");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8ea6ca95-5ede-4b33-ac3f-add02baaf091");

            migrationBuilder.CreateIndex(
                name: "IX_ChatLikes_PostId",
                table: "ChatLikes",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatLikes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReplyDateTime",
                table: "ChatReplies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7a494198-8ea3-4791-878f-e40bc20a7717");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "942e8755-5ed3-4bf0-bcd2-6fb1ed2bdf0a");
        }
    }
}
