using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecordShack.View_Models.Genre
{
    public class EditViewModel
    {
        public int GenreID { get; set; }

        [Required]
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }

        [Required]
        [Display(Name = "Genre Bio")]
        public string GenreBio { get; set; }

        [Required]
        [Display(Name = "Image Alt")]
        public string ImageAlt { get; set; }

        public string ImageSrc { get; set; }

        public EditViewModel(int id, string name, string bio, string imagesrc, string imagealt)
        {
            GenreID = id;
            GenreName = name;
            GenreBio = bio;
            ImageSrc = imagesrc;
            ImageAlt = imagealt;
        }

        public EditViewModel()
        {
                
        }

    }
}