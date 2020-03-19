using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Genre
{
    public class AdminIndexViewModel
    {
        [Display(Name = "Image")]
        public string ImageSrc { get; set; }

        [Display(Name = "Name")]
        public string GenreName { get; set; }

        [Display(Name = "Genre Bio")]
        public string GenreBio { get; set; }
        public List<tblGenre> GenresList { get; set; }

        public AdminIndexViewModel()
        {

        }

        public AdminIndexViewModel(List<tblGenre> genres)
        {
            GenresList = genres;
        }
    }
}