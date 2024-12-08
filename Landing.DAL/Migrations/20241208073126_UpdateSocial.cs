using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSocial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b43b4853-2d87-4ccc-8109-918b6a5cccca", "309fe612-9dd3-433d-a57d-a736c425da78" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8af1bd1c-99e4-452d-bd0d-34b24718a6eb", "8fd382a5-658e-45fe-ae9f-11fdfc613b65" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1194f4b2-ce46-4f72-8434-b416f7c6d1e2", "ac41ce66-4f19-4580-ac84-bd4ef948e85e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1194f4b2-ce46-4f72-8434-b416f7c6d1e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af1bd1c-99e4-452d-bd0d-34b24718a6eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b43b4853-2d87-4ccc-8109-918b6a5cccca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "309fe612-9dd3-433d-a57d-a736c425da78");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8fd382a5-658e-45fe-ae9f-11fdfc613b65");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac41ce66-4f19-4580-ac84-bd4ef948e85e");

            migrationBuilder.AddColumn<string>(
                name: "ApplecationUserId",
                table: "socials",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94e4b52d-539b-4a98-981f-0a2d3d8e4c57", null, "SuperAdmin", "SUPERADMIN" },
                    { "f8ed6a87-6654-4cec-b1e6-293282923a25", null, "Admin", "ADMIN" },
                    { "ffa9927f-33cb-41c0-b5f1-214aa4cfddfb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "26822e1d-611a-422f-89cc-cdab837166d0", 0, null, "42bbc8d1-00f8-49b4-bc69-5a3047b401e6", "user@design.com", true, null, false, null, "USER@DESIGN.COM", "USER@DESIGN.COM", "AQAAAAIAAYagAAAAEH2tta7pfVy9HcgRidiV3qyhYdDCUEn9YqvKCOcLGNYYZzmZZjv48KmEtoxRDZ0myA==", null, false, "9c5cacf4-c871-44bb-b6ee-5561ef4299da", false, "user@design.com" },
                    { "54abbe7a-2e1b-408a-afc9-c556e690c8ae", 0, null, "c7108f27-1706-4a7d-baf4-7bbabcdd26f6", "admin@design.com", true, null, false, null, "ADMIN@DESIGN.COM", "ADMIN@DESIGN.COM", "AQAAAAIAAYagAAAAEAg4taZGxCHver/zAZu6Z3wu/peHOJMEIwnKPvISYZkh2xWfc/NKu+sAGLFtvja2Tw==", null, false, "b02075df-ef17-494a-9e01-17548616ee37", false, "admin@design.com" },
                    { "fc331c45-3199-4997-9c3f-3840dd1b04da", 0, null, "7b6b3071-8c89-4544-97fd-9eb6ec10a192", "superadmin@design.com", true, null, false, null, "SUPERADMIN@DESIGN.COM", "SUPERADMIN@DESIGN.COM", "AQAAAAIAAYagAAAAEORcwZhe/dZ0cAM3HlK94Z2se+1vTMyObFg/cNmZG2PtChGmyIVlCA4MagNULp1pjg==", null, false, "d5c9c166-4386-450c-8811-0a693dda2987", false, "superadmin@design.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ffa9927f-33cb-41c0-b5f1-214aa4cfddfb", "26822e1d-611a-422f-89cc-cdab837166d0" },
                    { "f8ed6a87-6654-4cec-b1e6-293282923a25", "54abbe7a-2e1b-408a-afc9-c556e690c8ae" },
                    { "94e4b52d-539b-4a98-981f-0a2d3d8e4c57", "fc331c45-3199-4997-9c3f-3840dd1b04da" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_socials_ApplecationUserId",
                table: "socials",
                column: "ApplecationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_socials_AspNetUsers_ApplecationUserId",
                table: "socials",
                column: "ApplecationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_socials_AspNetUsers_ApplecationUserId",
                table: "socials");

            migrationBuilder.DropIndex(
                name: "IX_socials_ApplecationUserId",
                table: "socials");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ffa9927f-33cb-41c0-b5f1-214aa4cfddfb", "26822e1d-611a-422f-89cc-cdab837166d0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8ed6a87-6654-4cec-b1e6-293282923a25", "54abbe7a-2e1b-408a-afc9-c556e690c8ae" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94e4b52d-539b-4a98-981f-0a2d3d8e4c57", "fc331c45-3199-4997-9c3f-3840dd1b04da" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94e4b52d-539b-4a98-981f-0a2d3d8e4c57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8ed6a87-6654-4cec-b1e6-293282923a25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffa9927f-33cb-41c0-b5f1-214aa4cfddfb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26822e1d-611a-422f-89cc-cdab837166d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54abbe7a-2e1b-408a-afc9-c556e690c8ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc331c45-3199-4997-9c3f-3840dd1b04da");

            migrationBuilder.DropColumn(
                name: "ApplecationUserId",
                table: "socials");

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b43b4853-2d87-4ccc-8109-918b6a5cccca", "309fe612-9dd3-433d-a57d-a736c425da78" },
                    { "8af1bd1c-99e4-452d-bd0d-34b24718a6eb", "8fd382a5-658e-45fe-ae9f-11fdfc613b65" },
                    { "1194f4b2-ce46-4f72-8434-b416f7c6d1e2", "ac41ce66-4f19-4580-ac84-bd4ef948e85e" }
                });
        }
    }
}
