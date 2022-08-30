using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataAccess.Migrations
{
    public partial class add_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerException = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "UseCaseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UseCaseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCaseLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserUseCases",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UseCaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUseCases", x => new { x.UserId, x.UseCaseId });
                    table.ForeignKey(
                        name: "FK_UserUseCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPosts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPosts", x => new { x.CategoryId, x.PostId });
                    table.ForeignKey(
                        name: "FK_CategoryPosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Training" },
                    { 2, null, null, null, null, "Search Engine Optimization" },
                    { 3, null, null, null, null, "Food" },
                    { 4, null, null, null, null, "Travel" },
                    { 5, null, null, null, null, "Fashion" },
                    { 6, null, null, null, null, "Personal" },
                    { 7, null, null, null, null, "Art" },
                    { 8, null, null, null, null, "Photography" },
                    { 9, null, null, null, null, "Cookbooks" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Admin" },
                    { 2, null, null, null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 10, null, null, null, null, "Sunrise" },
                    { 9, null, null, null, null, "Sunset" },
                    { 8, null, null, null, null, "Siberian cat" },
                    { 7, null, null, null, null, "Back" },
                    { 6, null, null, null, null, "Legs" },
                    { 1, null, null, null, null, "Pies" },
                    { 4, null, null, null, null, "Web Design" },
                    { 3, null, null, null, null, "Pasta" },
                    { 2, null, null, null, null, "Cookies" },
                    { 11, null, null, null, null, "Cheese" },
                    { 5, null, null, null, null, "Software" },
                    { 12, null, null, null, null, "Soft" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Email", "Image", "ModifiedAt", "ModifiedBy", "Name", "Password", "RoleId", "Username" },
                values: new object[] { 3, null, null, "admin@gmail.com", null, null, null, "Admin", "$2a$11$IlELpiAWwFM5KlFeE7lxDewq/g/cBKzZiCtj86bpfy1yOCLiuBgVa", 1, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Email", "Image", "ModifiedAt", "ModifiedBy", "Name", "Password", "RoleId", "Username" },
                values: new object[] { 1, null, null, "mark@gmail.com", null, null, null, "Mark", "$2a$11$QdC/HWYu7Hwdy0HzEOh3ku2L9UCc9bm/W6hOV5H9yhv1STGiNnb8W", 2, "mark86" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Email", "Image", "ModifiedAt", "ModifiedBy", "Name", "Password", "RoleId", "Username" },
                values: new object[] { 2, null, null, "elenore@gmail.com", null, null, null, "Elenore", "$2a$11$.XhW/RWpZ0TN8T4sXS69.u/gE6MRAceXeIouW9jbb/dUttT/KLluu", 2, "elenore86" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", null, null, null, null, "Mom's cheese pie", 1 },
                    { 2, "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", null, null, null, null, "Welcome to everyone", 1 },
                    { 3, "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", null, null, null, null, "Spongebob Squarepants", 1 },
                    { 4, "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", null, null, null, null, "New York City", 1 },
                    { 5, "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", null, null, null, null, "Sunset behind the rock", 2 },
                    { 6, "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", null, null, null, null, "Long live the king", 2 }
                });

            migrationBuilder.InsertData(
                table: "CategoryPosts",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 6 },
                    { 5, 6 },
                    { 6, 5 },
                    { 8, 5 },
                    { 9, 4 },
                    { 7, 2 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "ParentId", "PostId", "UserId" },
                values: new object[,]
                {
                    { 8, "Hello", null, null, null, null, null, 2, 2 },
                    { 9, "Share more", null, null, null, null, null, 2, 2 },
                    { 13, "Saved", null, null, null, null, null, 6, 2 },
                    { 12, "Wonderful", null, null, null, null, null, 6, 2 },
                    { 6, "Ok", null, null, null, null, null, 1, 2 },
                    { 11, "Thanks", null, null, null, null, null, 5, 2 },
                    { 2, "Good", null, null, null, null, null, 1, 1 },
                    { 1, "Helpful", null, null, null, null, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "TagPosts",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 6, 2 },
                    { 6, 11 },
                    { 5, 7 },
                    { 4, 6 },
                    { 4, 5 },
                    { 3, 9 },
                    { 6, 9 },
                    { 2, 9 },
                    { 2, 12 },
                    { 2, 11 },
                    { 1, 1 },
                    { 1, 3 },
                    { 6, 10 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "ParentId", "PostId", "UserId" },
                values: new object[] { 3, "For me too", null, null, null, null, 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "ParentId", "PostId", "UserId" },
                values: new object[] { 5, "Great", null, null, null, null, 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "ParentId", "PostId", "UserId" },
                values: new object[] { 10, "Cool.", null, null, null, null, 9, 2, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "ParentId", "PostId", "UserId" },
                values: new object[] { 4, "Cool!", null, null, null, null, 3, 1, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "ParentId", "PostId", "UserId" },
                values: new object[] { 7, "!!", null, null, null, null, 3, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPosts_PostId",
                table: "CategoryPosts",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPosts");

            migrationBuilder.DropTable(
                name: "ExceptionLogs");

            migrationBuilder.DropTable(
                name: "UseCaseLogs");

            migrationBuilder.DropTable(
                name: "UserUseCases");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
