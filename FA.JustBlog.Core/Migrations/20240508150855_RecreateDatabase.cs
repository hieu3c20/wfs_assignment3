using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Tags",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tags",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostContent",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("99f46327-5753-421a-9ffc-bc87e54774ea"),
                column: "Name",
                value: "User");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("706e2fa2-d699-4b42-b012-b3472c3ffe15"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0fd5682c-21a8-4652-a740-db38bb9e6f5a", "AQAAAAIAAYagAAAAEK2G+jhE/YOuH+HETJS4j3eQ6NtXfFfxSZTPT5BDiP1NI16geA9Bpk0h/6Lbl1kyrQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba6ffe22-0cd9-4620-a03e-457b0d66da63", "AQAAAAIAAYagAAAAEP8X8HnJV0louc+UR11z+qXxjMrj+0MeJNdmdlprViIDwTj5fO2zOz8l9x05Lbuv5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b2c0e4f9-b5b7-4578-bdad-0eb1040147a2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1275536-b38e-4db5-b250-0160ff206b28", "AQAAAAIAAYagAAAAEIOotaffBxaQA90zvhD7xQ+/M5Miv03dUkQYMzhwH4tdQMinLHzbq9wIk0MXFRPq4w==" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 5, 8, 22, 8, 54, 590, DateTimeKind.Local).AddTicks(9267));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Tags",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tags",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostContent",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("99f46327-5753-421a-9ffc-bc87e54774ea"),
                column: "Name",
                value: "USER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("706e2fa2-d699-4b42-b012-b3472c3ffe15"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7b36b86-2b0b-4055-953f-9cb2f00240b8", "AQAAAAIAAYagAAAAEF9gMEHoqyJ8un2hZd8R9yuVr8EQlHMFjb13HRaW0g4aRksYOoaZOeoXcgBqlTFskA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8efae68f-9a89-4445-8f22-82a2ee84518a", "AQAAAAIAAYagAAAAENlnAC79uxJu99KfccLzaP0MHEt/8CzZ03RvxOFhSS51LqItAQx0MbNomHvCazn52g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b2c0e4f9-b5b7-4578-bdad-0eb1040147a2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa6f4b35-b529-48f0-9271-4c49c0acecfa", "AQAAAAIAAYagAAAAEJ4ovYJRRcMPiL/iNbBshYzXuodxs13trA+uQKygEa4ZkOSnXxMtFYy2o3+eCCvFAg==" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 4, 12, 14, 14, 48, 450, DateTimeKind.Local).AddTicks(807));
        }
    }
}
