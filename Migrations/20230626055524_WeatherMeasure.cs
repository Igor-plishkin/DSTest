using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DSTest.Migrations
{
    /// <inheritdoc />
    public partial class WeatherMeasure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MoscowTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    AirHumidity = table.Column<float>(type: "real", nullable: false),
                    DewPoint = table.Column<float>(type: "real", nullable: false),
                    Pressure = table.Column<int>(type: "integer", nullable: false),
                    WindDirection = table.Column<string>(type: "text", nullable: true),
                    WindSpeed = table.Column<int>(type: "integer", nullable: true),
                    Cloudiness = table.Column<int>(type: "integer", nullable: true),
                    LowCloudiness = table.Column<int>(type: "integer", nullable: true),
                    HorizontalVisibility = table.Column<string>(type: "text", nullable: true),
                    WeatherConditions = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherMeasures", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherMeasures");
        }
    }
}
