using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain
{
    public class Album
    {
        public Album()
        {            
            Songs = new List<AlbumSong>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<AlbumSong> Songs { get; set; }        

    }
}
