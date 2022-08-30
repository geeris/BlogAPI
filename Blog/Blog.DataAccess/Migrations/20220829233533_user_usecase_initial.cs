using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataAccess.Migrations
{
    public partial class user_usecase_initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserUseCases",
                columns: new[] { "UseCaseId", "UserId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 16, 1 },
                    { 2, 1 },
                    { 17, 1 },
                    { 20, 1 },
                    { 23, 1 },
                    { 25, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 16, 2 },
                    { 17, 2 },
                    { 18, 1 },
                    { 1, 1 },
                    { 27, 3 },
                    { 11, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 3 },
                    { 26, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 3 },
                    { 17, 3 },
                    { 18, 3 },
                    { 20, 3 },
                    { 23, 3 },
                    { 25, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserUseCases",
                columns: new[] { "UseCaseId", "UserId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ache36xOe33Mol7lA1oWp.Jtg3xahOtn7Pjiy0ejM9Kmy2iRL6DHW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$5yR95gHxKTV/fjJGfYUflOkVmAGN5QTJo0wLUEv9dgW7ra56APWVC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$.QYx2hWpfIDVgN7BfBca8.pbSoVlRa1Aic7k.M4Cta6ooa4vBu0e.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 20, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 23, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 25, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 27, 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$QdC/HWYu7Hwdy0HzEOh3ku2L9UCc9bm/W6hOV5H9yhv1STGiNnb8W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$.XhW/RWpZ0TN8T4sXS69.u/gE6MRAceXeIouW9jbb/dUttT/KLluu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$IlELpiAWwFM5KlFeE7lxDewq/g/cBKzZiCtj86bpfy1yOCLiuBgVa");
        }
    }
}
