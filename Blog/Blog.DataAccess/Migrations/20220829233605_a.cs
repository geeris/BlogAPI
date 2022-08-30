using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataAccess.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$f.hh.YJ7I/3sNafAqxlGy.psWxZgcjkbgh6nUUcazbpiv5LVbA1be");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$4LHMQgAUwWVfTGRK/ul3KeHn2ze1sQ4sMCGK9v7L.pF0ycHBe/.VO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$gdoHtCyC8J1kZ4EBvcch3Oh955h6/Acyz1nVg.MTzBJ.tqo9vOJbC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
