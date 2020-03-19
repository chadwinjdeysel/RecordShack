using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Artist
{
    public class DetailsViewModel
    {
        public tblArtist Artist { get; set; }
        public List<tblRecord> RecordsList { get; set; }

        public DetailsViewModel(tblArtist artist, List<tblRecord> recordslist)
        {
            Artist = artist;
            RecordsList = recordslist.Where(x => x.ArtistID == Artist.ArtistID).ToList();
        }
    }
}