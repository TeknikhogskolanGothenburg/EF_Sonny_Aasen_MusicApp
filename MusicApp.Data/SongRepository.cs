using MusicApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data
{
    public class SongRepository : GenericRepository<MusicContext, Song>
    {
    }
}
