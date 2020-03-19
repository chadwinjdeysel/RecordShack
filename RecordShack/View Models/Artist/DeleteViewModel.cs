using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Artist
{
    public class DeleteViewModel
    {
        public tblArtist Artist { get; set; }
        public List<tblRecord> RecordsList { get; set; }
        [Display(Name = "Confirm Password")]
        public string Password { get; set; }

        public DeleteViewModel(tblArtist artist, List<tblRecord> records)
        {
            Artist = artist;
            RecordsList = records.Where(x => x.ArtistID == Artist.ArtistID).ToList();   
        }

        public DeleteViewModel()
        {

        }
    }
}