using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RecordShack.Models;

namespace RecordShack.View_Models.Artist
{
    public class AdminIndexViewModel
    {

        [Display(Name = "Image")]
        public string ImageSrc { get; set; }

        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Display(Name = "Artist Bio")]
        public string ArtistBio { get; set; }

        public List<tblArtist> ArtistList { get; set; }

        public AdminIndexViewModel()
        {

        }

        public AdminIndexViewModel(List<tblArtist> artists)
        {
            ArtistList = artists;
        }
    }
}