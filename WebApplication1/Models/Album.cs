﻿namespace WebApplication1.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }    
        
        

    }
}