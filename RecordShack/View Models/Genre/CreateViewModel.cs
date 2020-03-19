using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Genre
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }

        [Required]
        [Display(Name = "Genre Bio")]
        public string GenreBio { get; set; }

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