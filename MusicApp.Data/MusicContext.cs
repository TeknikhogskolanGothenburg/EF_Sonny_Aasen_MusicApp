using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using MusicApp.Domain;

namespace MusicApp.Data
{
    public class MusicContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<AlbumSong> AlbumSong { get; set; }
        public DbSet<ArtistSong> ArtistSong { get; set; }



        public static readonly LoggerFactory MusicLoggerFactory
           = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level)
                => category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information, true)
           });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                  //  .UseLoggerFactory(MusicLoggerFactory)
                  // .UseSqlServer("Server = SONNY-DATOR\\SQLEXPRESS;" +
                  //             "Database = MusicDb; " +
                  //            "Trusted_Connection = True;" +
                  //            "MultipleActiveResultSets=true;");
                  .UseSqlServer("Server = (localdb)\\mssqllocaldb; " +
                                "Database = MyMovieDb; " +
                                "Trusted_Connection = True;" +
                                "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumSong>().HasKey(a => new { a.AlbumId, a.SongId });
            modelBuilder.Entity<ArtistSong>().HasKey(a => new { a.ArtistId, a.SongId });
        }
    }
}
