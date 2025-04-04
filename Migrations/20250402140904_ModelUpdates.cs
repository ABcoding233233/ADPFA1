using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Staff",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Staff",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Staff",
                newName: "StaffID");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ServiceRequests",
                newName: "ServiceType");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ServiceRequests",
                newName: "RequestID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reports",
                newName: "ReportID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Citizens",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Citizens",
                newName: "CitizenID");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Staff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CitizenID",
                table: "ServiceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CitizenID",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReportType",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Citizens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Citizens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Citizens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "CitizenID",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "CitizenID",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Citizens");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Staff",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Staff",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StaffID",
                table: "Staff",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ServiceType",
                table: "ServiceRequests",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "RequestID",
                table: "ServiceRequests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ReportID",
                table: "Reports",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Citizens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CitizenID",
                table: "Citizens",
                newName: "Id");
        }
    }
}
