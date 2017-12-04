﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }    
        
        public virtual ICollection<Album> Album { get; set; }

        

    }
}