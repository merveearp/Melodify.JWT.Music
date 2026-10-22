using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Melodify.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SetPackageUsageLimits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "AdInterval", "Description", "HasAds", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "SongsPerPlaylistLimit" },
                values: new object[] { 5, "Reklamlı ve sınırlı kullanımlı ücretsiz paket", true, 7, 3, 100, 3, 30 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "Description", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "PreviewSecondsAfterLimit", "SongsPerPlaylistLimit" },
                values: new object[] { "Öğrenci doğrulamasıyla Premium kullanım hakları", 90, 30, 500, 20, 15, 200 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "Description", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "PreviewSecondsAfterLimit", "SongsPerPlaylistLimit" },
                values: new object[] { "Reklamsız ve yüksek kullanım kotalı üyelik", 90, 30, 500, 20, 15, 200 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Reklamsız, dinleme ve atlama kotası olmayan üyelik", 189.90m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                columns: new[] { "AdInterval", "Description", "HasAds", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "SongsPerPlaylistLimit" },
                values: new object[] { null, "Ücretsiz başlangıç paketi", false, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                columns: new[] { "Description", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "PreviewSecondsAfterLimit", "SongsPerPlaylistLimit" },
                values: new object[] { "Öğrenciler için avantajlı üyelik paketi", null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3,
                columns: new[] { "Description", "HistoryVisibleDays", "HourlySkipLimit", "MonthlyListeningLimit", "PlaylistLimit", "PreviewSecondsAfterLimit", "SongsPerPlaylistLimit" },
                values: new object[] { "Premium müzik üyeliği", null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Tüm içeriklere erişim sağlayan üyelik paketi", 149.90m });
        }
    }
}
