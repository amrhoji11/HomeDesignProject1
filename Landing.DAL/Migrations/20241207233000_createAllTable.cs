using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Migrations
{
    /// <inheritdoc />
    public partial class createAllTable : Migration
    {
        /// <inheritdoc />
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "flaticons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flaticons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeLabels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplecationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profiles_AspNetUsers_ApplecationUserId",
                        column: x => x.ApplecationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Designs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlaticonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designs_flaticons_FlaticonId",
                        column: x => x.FlaticonId,
                        principalTable: "flaticons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    PProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comments_profiles_PProfileId",
                        column: x => x.PProfileId,
                        principalTable: "profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feedbacks_profiles_PProfileId",
                        column: x => x.PProfileId,
                        principalTable: "profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "massages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YourMassage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_massages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_massages_profiles_PProfileId",
                        column: x => x.PProfileId,
                        principalTable: "profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "socials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    PProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_socials_profiles_PProfileId",
                        column: x => x.PProfileId,
                        principalTable: "profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Designs_DesignId",
                        column: x => x.DesignId,
                        principalTable: "Designs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogs_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1194f4b2-ce46-4f72-8434-b416f7c6d1e2", null, "SuperAdmin", "SUPERADMIN" },
                    { "8af1bd1c-99e4-452d-bd0d-34b24718a6eb", null, "Admin", "ADMIN" },
                    { "b43b4853-2d87-4ccc-8109-918b6a5cccca", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "309fe612-9dd3-433d-a57d-a736c425da78", 0, null, "5098e888-8f9f-4781-ba6b-3490599701a8", "user@design.com", true, null, false, null, "USER@DESIGN.COM", "USER@DESIGN.COM", "AQAAAAIAAYagAAAAELT+SR5QZmcktKZWADGODIipIRr4TNN6GawKf7lTty3rt1aEclWXtyGR+srnHsyTdA==", null, false, "117e2be0-0f67-44b8-966d-c57951d81827", false, "user@design.com" },
                    { "8fd382a5-658e-45fe-ae9f-11fdfc613b65", 0, null, "58c40389-f7c7-4836-9a7c-dc65d4cfdd5a", "admin@design.com", true, null, false, null, "ADMIN@DESIGN.COM", "ADMIN@DESIGN.COM", "AQAAAAIAAYagAAAAEJgtJR5vlTkqbwe5LjZxC4XJ2JLaRv8FTrxrSaGvRxyTi5z1tIzJaFRKSjzJt0yYgQ==", null, false, "5d20cbd4-1927-4169-aebf-ca0711549a0e", false, "admin@design.com" },
                    { "ac41ce66-4f19-4580-ac84-bd4ef948e85e", 0, null, "5cf36534-0a59-42ff-904e-be7b5c82ca85", "superadmin@design.com", true, null, false, null, "SUPERADMIN@DESIGN.COM", "SUPERADMIN@DESIGN.COM", "AQAAAAIAAYagAAAAEPEVWbzuoBx1dAW9emWW8XbvlIGY4E2RCa5YMuTHogp52ey7QjW291g8ftIKg+bReQ==", null, false, "be6608ff-6f79-4103-8545-6fa9f2051694", false, "superadmin@design.com" }
                });

            migrationBuilder.InsertData(
                table: "flaticons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "kitchen" },
                    { 2, "living-room" },
                    { 3, "bathroom" },
                    { 4, "garden" },
                    { 5, "office" },
                    { 6, "dining-room" },
                    { 7, "balcony" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b43b4853-2d87-4ccc-8109-918b6a5cccca", "309fe612-9dd3-433d-a57d-a736c425da78" },
                    { "8af1bd1c-99e4-452d-bd0d-34b24718a6eb", "8fd382a5-658e-45fe-ae9f-11fdfc613b65" },
                    { "1194f4b2-ce46-4f72-8434-b416f7c6d1e2", "ac41ce66-4f19-4580-ac84-bd4ef948e85e" }
                });

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_ItemId",
                table: "blogs",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ParentCommentId",
                table: "comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_PProfileId",
                table: "comments",
                column: "PProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Designs_FlaticonId",
                table: "Designs",
                column: "FlaticonId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_PProfileId",
                table: "feedbacks",
                column: "PProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_DesignId",
                table: "Items",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_massages_PProfileId",
                table: "massages",
                column: "PProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_ApplecationUserId",
                table: "profiles",
                column: "ApplecationUserId",
                unique: true,
                filter: "[ApplecationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_socials_PProfileId",
                table: "socials",
                column: "PProfileId");
        }

        /// <inheritdoc />
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
                name: "blogs");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "HomeLabels");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "massages");

            migrationBuilder.DropTable(
                name: "socials");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "Designs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "flaticons");
        }
    }
}
