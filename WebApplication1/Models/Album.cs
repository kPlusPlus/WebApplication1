using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Review> Review { get; set; }

        
    }
}