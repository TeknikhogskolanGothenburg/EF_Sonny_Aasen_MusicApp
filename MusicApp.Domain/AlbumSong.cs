﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain
{
    public class AlbumSong
    {
       // public int AlbumSongId { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }

        public Album Album { get; set; }
        public Song Song { get; set; }
    }
}
