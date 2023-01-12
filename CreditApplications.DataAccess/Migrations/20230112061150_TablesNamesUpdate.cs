using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditApplications.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TablesNamesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditApplication_ApplicationStatus_ApplicationStatusId",
                table: "CreditApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditApplication_Customer_CustomerId",
                table: "CreditApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditApplication_Employee_EmployeeId",
                table: "CreditApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditApplication_ProductType_ProductTypeId",
                table: "CreditApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditApplication",
                table: "CreditApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationStatus",
                table: "ApplicationStatus");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "CreditApplication",
                newName: "CreditApplications");

            migrationBuilder.RenameTable(
                name: "ApplicationStatus",
                newName: "ApplicationStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditApplication_ProductTypeId",
                table: "CreditApplications",
                newName: "IX_CreditApplications_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditApplication_EmployeeId",
                table: "CreditApplications",
                newName: "IX_CreditApplications_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditApplication_CustomerId",
                table: "CreditApplications",
                newName: "IX_CreditApplications_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditApplication_ApplicationStatusId",
                table: "CreditApplications",
                newName: "IX_CreditApplications_ApplicationStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditApplications",
                table: "CreditApplications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationStatuses",
                table: "ApplicationStatuses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CreditApplications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfLastStatusChange", "DateOfSubmission" },
                values: new object[] { new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_CreditApplications_ApplicationStatuses_ApplicationStatusId",
                table: "CreditApplications",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditApplications_Customers_CustomerId",
                table: "CreditApplications",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditApplications_Employees_EmployeeId",
                table: "CreditApplications",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditApplications_ProductTypes_ProductTypeId",
                table: "CreditApplications",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditApplications_ApplicationStatuses_ApplicationStatusId",
                table: "CreditApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditApplications_Customers_CustomerId",
                table: "CreditApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditApplications_Employees_EmployeeId",
                table: "CreditApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditApplications_ProductTypes_ProductTypeId",
                table: "CreditApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditApplications",
                table: "CreditApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationStatuses",
                table: "ApplicationStatuses");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductType");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "CreditApplications",
                newName: "CreditApplication");

            migrationBuilder.RenameTable(
                name: "ApplicationStatuses",
                newName: "ApplicationStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employee",
                newName: "IX_Employee_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditApplications_ProductTypeId",
                table: "CreditApplication",
                newName: "IX_CreditApplication_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditApplications_EmployeeId",
                table: "CreditApplication",
                newName: "IX_CreditApplication_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditApplications_CustomerId",
                table: "CreditApplication",
                newName: "IX_CreditApplication_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditApplications_ApplicationStatusId",
                table: "CreditApplication",
                newName: "IX_CreditApplication_ApplicationStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditApplication",
                table: "CreditApplication",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationStatus",
                table: "ApplicationStatus",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CreditApplication",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfLastStatusChange", "DateOfSubmission" },
                values: new object[] { new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_CreditApplication_ApplicationStatus_ApplicationStatusId",
                table: "CreditApplication",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditApplication_Customer_CustomerId",
                table: "CreditApplication",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditApplication_Employee_EmployeeId",
                table: "CreditApplication",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditApplication_ProductType_ProductTypeId",
                table: "CreditApplication",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
