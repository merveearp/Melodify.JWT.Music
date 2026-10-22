using Melodify.EntityLayer.Entities;
using Melodify.EntityLayer.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Melodify.DataAccessLayer.Context
{
    public class MusicContext : IdentityDbContext<AppUser>
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public DbSet<SongLike> SongLikes { get; set; }
        public DbSet<ListeningHistory> ListeningHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Playlist>()
               .HasOne(x => x.User)
               .WithMany(x => x.Playlists)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            //Aynı şarkı bir kullanıcı tarafından birden fazla kez beğenilemez.
            modelBuilder.Entity<SongLike>()
               .HasIndex(x => new
               {
                   x.UserId,
                   x.SongId
               })
               .IsUnique();

            modelBuilder.Entity<AppUser>()
                .HasOne(x => x.Package)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

          
            modelBuilder.Entity<PlaylistSong>()
                .HasKey(x => new
                {
                    x.PlaylistId,
                    x.SongId
                });

            modelBuilder.Entity<ListeningHistory>()
                .HasOne(x=>x.User)
                .WithMany(x => x.ListeningHistories)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ListeningHistory>()
                .HasOne(x => x.Song)
                .WithMany(x => x.ListeningHistories )
                .HasForeignKey(x => x.SongId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Package>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Package>()
                .HasIndex(x => x.PackageName)
                .IsUnique();

            modelBuilder.Entity<Package>()
                .HasIndex(x => x.Level)
                .IsUnique();


            modelBuilder.Entity<Package>().HasData(
             new Package
             {
                 PackageId = 1,
                 PackageName = "Free",
                 Description = "Reklamlı ve sınırlı kullanımlı ücretsiz paket",
                 Level = PackageLevel.Free,
                 Price = 0m,
                 IsActive = true,

                 MonthlyListeningLimit = 100,
                 HourlySkipLimit = 3,
                 PlaylistLimit = 3,
                 SongsPerPlaylistLimit = 30,
                 HistoryVisibleDays = 7,
                 HasAds = true,
                 AdInterval = 5,
                 PreviewSecondsAfterLimit = null
             },
             new Package
             {
                 PackageId = 2,
                 PackageName = "Student",
                 Description = "Öğrenci doğrulamasıyla Premium kullanım hakları",
                 Level = PackageLevel.Student,
                 Price = 49.90m,
                 IsActive = true,

                 MonthlyListeningLimit = 500,
                 HourlySkipLimit = 30,
                 PlaylistLimit = 20,
                 SongsPerPlaylistLimit = 200,
                 HistoryVisibleDays = 90,
                 HasAds = false,
                 AdInterval = null,
                 PreviewSecondsAfterLimit = 15
             },
             new Package
             {
                 PackageId = 3,
                 PackageName = "Premium",
                 Description = "Reklamsız ve yüksek kullanım kotalı üyelik",
                 Level = PackageLevel.Premium,
                 Price = 99.90m,
                 IsActive = true,

                 MonthlyListeningLimit = 500,
                 HourlySkipLimit = 30,
                 PlaylistLimit = 20,
                 SongsPerPlaylistLimit = 200,
                 HistoryVisibleDays = 90,
                 HasAds = false,
                 AdInterval = null,
                 PreviewSecondsAfterLimit = 15
             },
             new Package
             {
                 PackageId = 4,
                 PackageName = "Gold",
                 Description = "Reklamsız, dinleme ve atlama kotası olmayan üyelik",
                 Level = PackageLevel.Gold,
                 Price = 189.90m,
                 IsActive = true,

                 MonthlyListeningLimit = null,
                 HourlySkipLimit = null,
                 PlaylistLimit = null,
                 SongsPerPlaylistLimit = null,
                 HistoryVisibleDays = null,
                 HasAds = false,
                 AdInterval = null,
                 PreviewSecondsAfterLimit = null
             }
         );

        }
    }

}