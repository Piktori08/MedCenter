using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Med_Center.Migrations
{
    /// <inheritdoc />
    public partial class numerimifix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentCount",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentCount",
                table: "Doctors",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentCount",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AppointmentCount",
                table: "Doctors");
        }
    }
}
