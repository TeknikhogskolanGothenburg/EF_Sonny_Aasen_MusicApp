using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain
{
    public class Song
    {       
        public Song()
        {
            Artists = new List<ArtistSong>();
            Albums = new List<AlbumSong>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public List<ArtistSong> Artists { get; set; }
        public List<AlbumSong> Albums { get; set; }
    }
}
