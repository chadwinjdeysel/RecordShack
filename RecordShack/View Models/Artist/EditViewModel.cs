using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Artist
{
    public class EditViewModel
    {
        public int ArtistID { get; set; }

        [Required]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        [Display(Name = "Artist Bio")]
        public string ArtistBio { get; set; }

        [Required]
        [Display(Name = "Image Alt")]
        public string ImageAlt { get; set; }

        public string ImageSrc { get; set; }
        public EditViewModel(int id, string name, string bio, string imagesrc, string imagealt)
        {
            ArtistID = id;
            ArtistName = name;
            ArtistBio = bio;
            ImageAlt = imagealt;
            ImageSrc = imagesrc;
        }

        public EditViewModel()
        {

        }
    }
}