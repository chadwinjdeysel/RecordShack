using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Rating
{
    public class AddRatingViewModel
    {
        public int RecordID { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }

        public AddRatingViewModel()
        {

        }

    }
}