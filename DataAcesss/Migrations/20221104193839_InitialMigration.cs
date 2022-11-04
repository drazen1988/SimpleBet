using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcesss.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "ChatPosts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatPosts", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "Clans",
                columns: table => new
                {
                    ClanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClanDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clans", x => x.ClanId);
                });

            migrationBuilder.CreateTable(
                name: "ClanStats",
                columns: table => new
                {
                    ClanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvgCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ClanStatsAbs",
                columns: table => new
                {
                    ClanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinningBetsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ClanUsers",
                columns: table => new
                {
                    ClanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersCount = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsWinner = table.Column<bool>(type: "bit", nullable: false),
                    CountryDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnerException = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "LeaderBoard",
                columns: table => new
                {
                    Position = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HomeTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwayTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DrawCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AwayCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinningBetType = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "MatchResults",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    MatchDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwayTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinnersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MyBetList",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    HomeTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwayTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BetCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsWinningBet = table.Column<bool>(type: "bit", nullable: false),
                    MatchDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MyStats",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBetCount = table.Column<int>(type: "int", nullable: true),
                    WinningBetCount = table.Column<int>(type: "int", nullable: true),
                    BestWinningCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UsersPerClan",
                columns: table => new
                {
                    ClanId = table.Column<int>(type: "int", nullable: false),
                    ClanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersPerClan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "WinsPerDay",
                columns: table => new
                {
                    MatchDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatLikes",
                columns: table => new
                {
                    LikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    LikeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ChatReplies",
                columns: table => new
                {
                    ReplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatReplies", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_ChatReplies_ChatPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "ChatPosts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClanId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Clans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clans",
                        principalColumn: "ClanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryBets",
                columns: table => new
                {
                    CountryBetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CountryCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsWinningBet = table.Column<bool>(type: "bit", nullable: false),
                    CountryBetDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryBets", x => x.CountryBetId);
                    table.ForeignKey(
                        name: "FK_CountryBets_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    BetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    BetType = table.Column<int>(type: "int", nullable: false),
                    BetCoeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsWinningBet = table.Column<bool>(type: "bit", nullable: false),
                    BetDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.BetId);
                    table.ForeignKey(
                        name: "FK_Bets_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "a9d3ef3b-360e-4172-86e5-4b24c4449dcc", "Admin", "Admin" },
                    { "2", "7659ae18-5455-4270-bb76-512fb68801dc", "Korisnik", "Korisnik" }
                });

            migrationBuilder.InsertData(
                table: "Clans",
                columns: new[] { "ClanId", "ClanName", "UserId" },
                values: new object[,]
                {
                    { 1, "HRPRO", "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 2, "Erste", "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCoeficient", "CountryName", "IsWinner", "UserId" },
                values: new object[,]
                {
                    { 1, 400m, "Katar", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 2, 250m, "Ekvador", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 3, 80m, "Senegal", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 4, 15m, "Nizozemska", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 5, 8m, "Engleska", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 6, 700m, "Iran", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 7, 100m, "SAD", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 8, 150m, "Wales", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 9, 9m, "Argentina", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 10, 999m, "Saudijska Arabija", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 11, 150m, "Meksiko", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 12, 125m, "Poljska", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 13, 7m, "Francuska", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 14, 250m, "Australija", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 15, 40m, "Danska", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 16, 800m, "Tunis", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 17, 9m, "Španjolska", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 18, 750m, "Kostarika", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 19, 12m, "Njemačka", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 20, 400m, "Japan", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 21, 15m, "Belgija", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 22, 350m, "Kanada", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 23, 450m, "Maroko", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 24, 50m, "Hrvatska", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 25, 5m, "Brazil", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 26, 80m, "Srbija", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 27, 80m, "Švicarska", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 28, 350m, "Kamerun", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 29, 15m, "Portugal", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 30, 400m, "Gana", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 31, 60m, "Urugvaj", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" },
                    { 32, 600m, "Južna Koreja", false, "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ClanId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6", 0, 1, "77dd27c4-8531-4741-9231-2c0d859d0c09", "drazen.marinkovic1@gmail.com", false, "Dražen", "Marinković", true, null, "DRAZEN.MARINKOVIC1@GMAIL.COM", "DMARINKOVIC", "AQAAAAEAACcQAAAAELAPlQf8sVUM/Sc31lIipH7sBfuUsCGeZawx2x0YYRl4pDu1viNlCOk4SEiznbNjlw==", null, false, "QSJGIOPEXML4J3IXUW3PVXBZ7GB5YN46", false, "dmarinkovic" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ClanId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "45a0f303-506b-4a0e-b42f-0b1c814d84f7", 0, 2, "77dd27c4-8531-4741-9231-2c0d859d0c09", "tomislav.berisic@gmail.com", false, "Tomislav", "Berišić", true, null, "TOMISLAV.BERISIC@GMAIL.COM", "TBERISIC", "AQAAAAEAACcQAAAAECCRKBsGtZvndBuz9iFwly0sqK8/vI/2GskOb/RMBxQYQXXu/ZUBlmXye+qZ+PMxjg==", null, false, "QSJGIOPEXML4J3IXUW3PVXBZ7GB5YN46", false, "tberisic" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ClanId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d2b416d1-7861-4d6e-835e-4e1ebc65ce7b", 0, 2, "77dd27c4-8531-4741-9231-2c0d859d0c09", "test@test.com", false, "Pero", "Perić", true, null, "TEST@TEST.COM", "KORISNIK", "AQAAAAEAACcQAAAAECCRKBsGtZvndBuz9iFwly0sqK8/vI/2GskOb/RMBxQYQXXu/ZUBlmXye+qZ+PMxjg==", null, false, "QSJGIOPEXML4J3IXUW3PVXBZ7GB5YN46", false, "korisnik" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "45a0f303-506b-4a0e-b42f-0b1c814d84f7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "d2b416d1-7861-4d6e-835e-4e1ebc65ce7b" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClanId",
                table: "AspNetUsers",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_MatchId",
                table: "Bets",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatLikes_PostId",
                table: "ChatLikes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatReplies_PostId",
                table: "ChatReplies",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Clans_ClanName",
                table: "Clans",
                column: "ClanName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryName",
                table: "Countries",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryBets_CountryId",
                table: "CountryBets",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WebId",
                table: "Matches",
                column: "WebId",
                unique: true);

            migrationBuilder.CreateProcedures();
            migrationBuilder.CreateTriggers();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "ChatLikes");

            migrationBuilder.DropTable(
                name: "ChatReplies");

            migrationBuilder.DropTable(
                name: "ClanStats");

            migrationBuilder.DropTable(
                name: "ClanStatsAbs");

            migrationBuilder.DropTable(
                name: "ClanUsers");

            migrationBuilder.DropTable(
                name: "CountryBets");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "LeaderBoard");

            migrationBuilder.DropTable(
                name: "MatchResults");

            migrationBuilder.DropTable(
                name: "MyBetList");

            migrationBuilder.DropTable(
                name: "MyStats");

            migrationBuilder.DropTable(
                name: "UsersPerClan");

            migrationBuilder.DropTable(
                name: "WinsPerDay");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "ChatPosts");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Clans");
        }
    }
}
