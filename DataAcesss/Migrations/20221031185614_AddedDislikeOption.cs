using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcesss.Migrations
{
    public partial class AddedDislikeOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatReplies_ChatPosts_PostId",
                table: "ChatReplies");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "ChatReplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikeType",
                table: "ChatLikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "67dcfad6-c8b4-4c07-9598-2ea0dd3809ff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "09a211b8-8912-4a84-9101-0eaca5cbeb81");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatReplies_ChatPosts_PostId",
                table: "ChatReplies",
                column: "PostId",
                principalTable: "ChatPosts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatReplies_ChatPosts_PostId",
                table: "ChatReplies");

            migrationBuilder.DropColumn(
                name: "LikeType",
                table: "ChatLikes");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "ChatReplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ff8544d5-0971-4120-a702-d186daae6d5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "036cbf99-dcd4-4d4b-9aae-d6e1f3197815");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatReplies_ChatPosts_PostId",
                table: "ChatReplies",
                column: "PostId",
                principalTable: "ChatPosts",
                principalColumn: "PostId");
        }
    }
}
