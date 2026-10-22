using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Melodify.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceSongPackageWithUsageLimits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Packages_PackageId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PackageId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Songs");

            migrationBuilder.AddColumn<int>(
                name: "AdInterval",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasAds",
                table: "Packages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HistoryVisibleDays",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HourlySkipLimit",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthlyListeningLimit",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaylistLimit",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviewSecondsAfterLimit",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SongsPerPlaylistLimit",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "AdInterval", "HasAds", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "PreviewSecondsAfterLimit", "SongsPerPlaylistLimit" },
                values: new object[] { null, false, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "AdInterval", "HasAds", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "PreviewSecondsAfterLimit", "SongsPerPlaylistLimit" },
                values: new object[] { null, false, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "AdInterval", "HasAds", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "PreviewSecondsAfterLimit", "SongsPerPlaylistLimit" },
                values: new object[] { null, false, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "AdInterval", "HasAds", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "PreviewSecondsAfterLimit", "SongsPerPlaylistLimit" },
                values: new object[] { null, false, null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdInterval",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "HasAds",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "HistoryVisibleDays",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "HourlySkipLimit",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "MonthlyListeningLimit",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PlaylistLimit",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PreviewSecondsAfterLimit",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "SongsPerPlaylistLimit",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PackageId",
                table: "Songs",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Packages_PackageId",
                table: "Songs",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
