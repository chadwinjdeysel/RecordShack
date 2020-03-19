using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Artist
{
    public class CreateViewModel
    {

        [Required]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        [Display(Name = "Artist Bio")]
        public string ArtistBio { get; set; }

        [Required]
        public HttpPostedFileBase Image { get; set; }

        public string ImageSrc { get; set; }

        [Required]
        [Display(Name = "Image Alt")]
        public string ImageAlt { get; set; }

        public CreateViewModel()
        {
            
        }

    }
}