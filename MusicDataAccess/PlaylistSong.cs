//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlaylistSong
    {
        public long PlaylistSongID { get; set; }
        public long PlaylistID { get; set; }
        public long SongID { get; set; }
    
        public virtual Playlist Playlist { get; set; }
        public virtual Song Song { get; set; }
    }
}
