using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employee_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Role_RoleId",
                table: "EmployeeRole");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employee_EmployeeId",
                table: "EmployeeRole",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Role_RoleId",
                table: "EmployeeRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employee_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Role_RoleId",
                table: "EmployeeRole");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employee_EmployeeId",
                table: "EmployeeRole",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Role_RoleId",
                table: "EmployeeRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
