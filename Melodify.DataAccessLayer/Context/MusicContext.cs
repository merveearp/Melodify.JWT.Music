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

            modelBuilder.Entity<Song>()
                .HasOne(x => x.Package)
                .WithMany(x=>x.Songs)
                .HasForeignKey(x=>x.PackageId)
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
            Description = "Ücretsiz başlangıç paketi",
            Level = PackageLevel.Free,
            Price = 0m,
            IsActive = true
        },
        new Package
        {
            PackageId = 2,
            PackageName = "Student",
            Description = "Öğrenciler için avantajlı üyelik paketi",
            Level = PackageLevel.Student,
            Price = 49.90m,
            IsActive = true
        },
        new Package
        {
            PackageId = 3,
            PackageName = "Premium",
            Description = "Premium müzik üyeliği",
            Level = PackageLevel.Premium,
            Price = 99.90m,
            IsActive = true
        },
        new Package
        {
            PackageId = 4,
            PackageName = "Gold",
            Description = "Tüm içeriklere erişim sağlayan üyelik paketi",
            Level = PackageLevel.Gold,
            Price = 149.90m,
            IsActive = true
        }
         
        );
        
        
        }
    }

}