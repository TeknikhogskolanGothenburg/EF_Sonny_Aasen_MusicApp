using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Domain;


namespace MusicApp.UI
{
    /// <summary>
    /// As this program is not fully developed I would like to explain some of my thoughts and difficulties with the project
    /// for feedback.
    /// I have been using a connectionstring for sql server management studio that I have now changed to localdb,
    /// this is because I dont know how to open a localdb server. The given connectionstring during class does not work with
    /// server management studio.
    /// 
    /// I have had errors with Primary keys in many to many tables and not being able to fill the ArtistSong table for example,
    /// and the error says Cannot insert explicit value for identity column in table 'table' when IDENTITY_INSERT is set to OFF.
    /// 
    /// While i'm not sure i've implemented Async fully on AddArtistAsync, the purpose to use this over multithreading
    /// is that adding a new artist does not tax your processor and therefor multithreading is not needed.
    /// 
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
           // AddArtistAsync();
           // AddArtists();
           // FindArtistByName("Pink Floyd");
           // UpdateArtist(35);
           // FindArtistByName("Kamelot");
           // DeleteArtist(2);
           // FindArtistByName("Wintersun");
            AddSong();
            AddManyToManySongArtist();

        }

        private static void AddArtistAsync()
        {
            var artistRepo = new ArtistRepository();
            var artist = new Artist { Name = "Pink Floyd" };
            artistRepo.AddAsync(artist);
            artistRepo.Save();
        }

        private static void AddArtists()
        {
            var artistRepo = new ArtistRepository();
            var artistList = new List<Artist>();
            var artist1 = new Artist { Name = "Ensiferum" };
            var artist2 = new Artist { Name = "Ghost" };
            artistList.Add(artist1);
            artistList.Add(artist2);

            artistRepo.AddRange(artistList);
            artistRepo.Save();
        }

        private static void FindArtistByName(string name)
        {
            var context = new MusicContext();
            var query = from artists in context.Artists
                        where artists.Name == name
                        select artists;
            query.ToList();
            foreach (var artist in query)
            {
                Console.WriteLine(artist.Name + " Id " + artist.Id);
            }
            
        }

        private static void UpdateArtist(int id)
        {
            var context = new MusicContext();
            var query = from artists in context.Artists
                        where artists.Id == id
                        select artists;

            query.ToList();
            foreach (var artist in query)
            {
                artist.Name = "Kamelot";
                
            }
            context.SaveChanges();

        }

        private static void DeleteArtist(int id)
        {
            var context = new MusicContext();          
            var artist = context.Artists.Find(id);
            if (artist != null)
            {
                context.Artists.Remove(artist);
                context.SaveChanges();
            }

           
        }

        private static void AddSong()
        {
            var songRepo = new SongRepository();
            var song = new Song { Title = "Another brick in the wall"};
            songRepo.AddAsync(song);
            songRepo.Save();
        }

        private static void AddManyToManySongArtist()
        {
            var context = new MusicContext();
            var song = new Song { Title = "Time"};
            var artist = context.Artists.Find(3);
            context.Add(artist);
            context.Add(new ArtistSong { ArtistId = artist.Id, SongId = song.Id});
            context.SaveChanges();
        }
    }
}
