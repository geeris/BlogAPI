using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataAccess.Migrations
{
    public partial class fixed_useCaseLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAuthorized",
                table: "UseCaseLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$MLffD1Deu4DEavKxwmIsku51XiBAQ.5UhMynRAgbZEYgKJguyfiPi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$4KVkaWvvKRYmCOnKIzsObOLn9h/DpP7qAHwc1gUyBs/WA8qdKHqw2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$0HthCDtrr5yu3UpaMtjdw.ASjWUEg392/OuDKfzyFPcSogxaDOnwK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuthorized",
                table: "UseCaseLogs");

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
    }
}
