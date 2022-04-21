using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementAPI.Migrations
{
    public partial class DataOfDeletionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeesHistory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfDeletion",
                table: "EmployeesHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfDeletion",
                table: "EmployeesHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "LastName", "PositionName", "Salary" },
                values: new object[,]
                {
                    { 1, "Postova", "2001-04-12", "Aaa", "Bbb", "Cook", 20.0 },
                    { 2, "Postova", "1980-02-26", "Dedo", "Mraz", "Waiter", 20.0 }
                });

            migrationBuilder.InsertData(
                table: "EmployeesHistory",
                columns: new[] { "Id", "Address", "DateOfBirth", "DateOfDeletion", "EmployeeId", "FirstName", "LastName", "PositionName", "Salary" },
                values: new object[] { 1, "Postova", "2001-08-09", null, 2, "Eduard", "Pipes", "Cook", 20.0 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Cooking", "Cook" });
        }
    }
}
