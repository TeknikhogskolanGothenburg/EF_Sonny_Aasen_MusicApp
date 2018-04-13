using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain
{
    public class ArtistSong
    {
      //  public int ArtistSongId { get; set; }
        public int ArtistId { get; set; }
        public int SongId { get; set; }

        public Artist Artist { get; set; }
        public Song Song { get; set; }
    }
}
