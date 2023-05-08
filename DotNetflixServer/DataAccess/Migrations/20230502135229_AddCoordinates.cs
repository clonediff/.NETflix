using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Countries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Countries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -35.5, 149.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 47.333328000000002, 13.33333 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 40.5, 47.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 42.304482, 2.7213500000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 28.0, 3.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -64.896334999999993, 18.335764999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -14.276109999999999, -170.66389000000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -12.5, 18.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 42.5, 1.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -69.349999999999994, -2.233333 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 17.049999, -61.799999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 19.0, -66.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -31.383329, -64.066672999999994 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 40.0, 45.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 12.5297, 70.008700000000005 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 33.0, 66.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 23.91667, -77.666669999999996 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 24.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.16667, -59.533329000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 26.0, 50.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 53.0, 28.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 17.25, -88.75 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 50.833328000000002, 4.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 9.5, 2.25 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 7.5399890000000003, -5.5470800000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 26.629166999999999, -70.883611000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 21.916111000000001, 95.956111000000007 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 43.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -17.0, -65.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 44.0, 18.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 44.0, 18.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -22.0, 24.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 39.523651000000001, -87.125022999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 4.5, 114.66667200000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.0, -2.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -3.5, 30.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 27.5, 90.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -16.0, 167.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 41.902358999999997, 12.45332 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 54.758437999999998, -2.6953100000000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 47.0, 20.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 8.0, -66.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 18.093610999999999, -64.830278000000007 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 5.875, -162.05699999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 16.16667, 107.83332799999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 20.0, 105.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -1.0, 11.75 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 19.0, -72.416672000000005 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 5.0, -59.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.5, -15.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 8.0, -2.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 16.25, -61.583333000000003 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 15.5, -90.25 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 11.0, -10.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 12.0, -15.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 51.5, 10.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 51.0, 13.75 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 51.0, 9.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 36.133333, -5.3499999999999996 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 15.0, -86.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 22.283332999999999, 114.15000000000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 12.116667, -61.666666999999997 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 72.0, -40.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 38.352428000000003, 23.139949999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 42.0, 43.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.451667, 144.77027799999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 56.0, 10.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 11.5, 42.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 15.5, -61.333328000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 19.0, -70.666672000000005 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 27.0, 30.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 0.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -15.0, 30.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 27.162239, -13.203150000000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -19.0, 29.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 31.5, 34.75 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 20.0, 77.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -5.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 31.0, 36.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 33.0, 44.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 32.0, 53.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 53.0, -8.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 65.0, -18.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 40.0, -4.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 43.698292000000002, 10.39955 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 15.5, 47.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 16.0, -24.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 48.0, 68.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 19.327777999999999, -81.133611000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.0, 105.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 6.0, 12.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 60.108668999999999, -113.642578 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 25.5, 51.25 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 1.0, 38.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 35.0, 33.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 41.0, 75.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 1.421, 172.983994 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 35.0, 105.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 4.0, -72.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -12.183332999999999, 44.233333000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -1.0, 15.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 0.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 36.516666999999998, 127.8 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 39.0, 126.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 37.0, 128.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 42.633333, 20.916667 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 10.0, -84.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Lat", "Lng", "Name" },
                values: new object[] { 8.0, -5.0, "Кот-д'Ивуар" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 22.0, -79.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 29.5, 47.75 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 20.342220000000001, 104.344643 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 57.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -29.5, 28.25 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 6.5, -9.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 33.833328000000002, 35.833328000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 25.0, 17.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 56.0, 24.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 47.166671999999998, 9.5333299999999994 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 49.611671000000001, 6.1299999999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -20.299999, 57.583328000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 20.0, -12.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -20.0, 47.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 22.200555999999999, 113.545833 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 41.608640000000001, 21.745280000000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -13.5, 34.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 2.5, 112.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 17.0, -4.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 3.2000000000000002, 73.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 35.916671999999998, 14.43333 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 32.0, -5.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 14.066667000000001, -61.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 7.1130000000000004, 171.23599200000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 23.0, -102.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -18.0, 25.350000000000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 46.979424000000002, 28.389696900000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 43.733330000000002, 7.4166699999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 46.0, 105.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 41.591667000000001, 1.8377779999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 22.0, 98.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -22.0, 17.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 28.0, 84.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 16.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 10.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 52.5, 5.75 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.0, -85.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -42.0, 174.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -20.904305000000001, 165.618042 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 62.0, 10.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 24.0, 54.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 32.0, 35.166666999999997 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 21.0, 57.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 54.237222000000003, -4.5230560000000004 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -21.233332999999998, -159.76666700000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 30.0, 70.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 7.5030000000000001, 134.621002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 31.921569999999999, 35.203288999999998 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 8.9936000000000007, -79.519729999999996 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -6.0, 147.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -22.99333, -57.996391000000003 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -10.0, -76.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 52.0, 20.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 38.726348999999999, -9.1484299999999994 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 18.620833300000001, -91.939444399999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 55.534500000000001, -21.1357 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 60.0, 100.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 60.0, 100.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -2.0, 30.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 46.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 60.0, 100.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 39.759998000000003, -98.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.83333, -88.916672000000005 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -13.803100000000001, -172.178314 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 43.933331000000003, 12.449999999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 25.0, 45.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -26.522503, 31.465865999999998 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 41.833328000000002, 22.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -4.5833300000000001, 55.666671999999998 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 14.0, -14.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.08333, -61.200001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 17.33333, -62.75 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.883330000000001, -60.966670999999998 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 44.818919999999999, 20.459980000000002 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 43.5, 20.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 15.0, 100.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 1.3666700000000001, 103.800003 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 35.0, 38.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 48.666668000000001, 19.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 46.25, 15.16667 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -8.0, 159.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 6.0, 48.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 16.0, 30.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 4.0, -56.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 8.5, -11.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 39.0, 71.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 15.0, 100.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 24.0, 121.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -6.0, 35.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -8.7650000000000006, 126.093889 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 8.0, 1.1666700000000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -20.0, -175.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 11.0, -61.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -8.5171899999999994, 179.14477500000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 34.0, 9.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 40.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 39.059010000000001, 34.911549000000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 2.0, 33.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 41.707538999999997, 63.849110000000003 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 49.0, 32.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -135.0, -177.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -33.0, -56.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 61.892634999999999, -6.9118060000000003 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 6.9193769999999999, 158.15559400000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -18.0, 178.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 13.0, 122.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 64.0, 26.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -51.75, -59.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 46.0, 2.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 3.9338890000000002, -53.125782000000001 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -17.539194999999999, -149.556757 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 45.166671999999998, 15.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 7.0, 21.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 15.0, 19.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 42.5, 19.299999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 49.75, 15.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 50.083333000000003, 14.433332999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -30.0, -71.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 47.000155999999997, 8.0142690000000005 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 62.0, 15.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 7.0, 81.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -2.0, -77.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 2.0, 10.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 15.0, 39.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 59.0, 26.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 8.0, 38.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { -30.0, 26.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 44.0, 21.0 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 42.783000000000001, 19.466999999999999 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 18.25, -77.5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "Lat", "Lng" },
                values: new object[] { 35.685360000000003, 139.75309799999999 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Countries");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 108,
                column: "Name",
                value: "Кот-д’Ивуар");
        }
    }
}
