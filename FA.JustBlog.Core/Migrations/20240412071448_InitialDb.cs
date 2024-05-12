using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CommentText = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), null, "Blog_Owner", null },
                    { new Guid("99f46327-5753-421a-9ffc-bc87e54774ea"), null, "USER", null },
                    { new Guid("c84066e6-bf5e-4652-b948-2ba8d78b6cd0"), null, "Contributor", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("706e2fa2-d699-4b42-b012-b3472c3ffe15"), "Duis dignissim rutrum dictum. Nunc porttitor, ex id tristique iaculis, sem lectus placerat nisi, sed egestas diam magna et nisi.\n\n", 0, 4, "a7b36b86-2b0b-4055-953f-9cb2f00240b8", "user@gmail.com", false, "Yuu", "The", false, null, "USER@GMAIL.COM", "USER NAME", "AQAAAAIAAYagAAAAEF9gMEHoqyJ8un2hZd8R9yuVr8EQlHMFjb13HRaW0g4aRksYOoaZOeoXcgBqlTFskA==", null, false, null, false, "user name" },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "Curabitur cursus nisi tellus, vitae aliquam risus pharetra ac. Nullam lobortis nec massa vel hendrerit. Integer tincidunt vehicula risus eu.", 0, 24, "8efae68f-9a89-4445-8f22-82a2ee84518a", "admin@gmail.com", false, "Ass", "Mean", false, null, "ADMIN@GMAIL.COM", "ADMIN NAME", "AQAAAAIAAYagAAAAENlnAC79uxJu99KfccLzaP0MHEt/8CzZ03RvxOFhSS51LqItAQx0MbNomHvCazn52g==", null, false, null, false, "admin name" },
                    { new Guid("b2c0e4f9-b5b7-4578-bdad-0eb1040147a2"), "Donec tincidunt est ac est semper feugiat. Maecenas vulputate tristique metus vel pretium. Vestibulum ante ipsum primis in faucibus orci.", 0, 14, "aa6f4b35-b529-48f0-9271-4c49c0acecfa", "Contributor@gmail.com", false, "Corn", "Cheese", false, null, "Contributor@GMAIL.COM", "Contributor NAME", "AQAAAAIAAYagAAAAEJ4ovYJRRcMPiL/iNbBshYzXuodxs13trA+uQKygEa4ZkOSnXxMtFYy2o3+eCCvFAg==", null, false, null, false, "Contributor name" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "Description for movies", "Movies", "movies" },
                    { 2, "Description for sports", "Sports", "sports" },
                    { 3, "Description for art and design", "Art and Design", "art-and-design" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 1, "Penaldo", "CR7", "cristiano-ronaldo" },
                    { 2, 3, "Si Tax", "Messi", "lionel-messi" },
                    { 3, 5, "Kung fu", "Martial Art", "martial-art" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("99f46327-5753-421a-9ffc-bc87e54774ea"), new Guid("706e2fa2-d699-4b42-b012-b3472c3ffe15") },
                    { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") },
                    { new Guid("c84066e6-bf5e-4652-b948-2ba8d78b6cd0"), new Guid("b2c0e4f9-b5b7-4578-bdad-0eb1040147a2") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { 1, 2, true, "Sport bla bla", new DateTime(2024, 4, 12, 14, 14, 48, 450, DateTimeKind.Local).AddTicks(807), true, 0, "CR7 < Messi", "Today I learned that CR7 is sub-goat", 0, "ronaldo-is-sub-goat", 0 },
                    { 2, 1, false, "Movies bleh bleh", new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, "kung fu panda 4 sucks", "Kung Fu Panda 4 is not reached its potential", 0, "kung-fu-panda-4-sucks", 0 },
                    { 3, 3, false, "For content creators", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0, "ai superior", "AI is replacing humans in content creating", 0, "ai-is-dominant", 0 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
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
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps",
                column: "TagId");
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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
