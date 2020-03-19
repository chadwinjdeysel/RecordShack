using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;
using RecordShack.View_Models.Rating;

namespace RecordShack.View_Models.Record
{
    public class DetailsViewModel
    {
        public tblRecord Record { get; set; }
        public List<tblRating> RatingsList { get; set; }
        public double OverallRating { get; set; }

        public AddRatingViewModel RatingVM { get; set; }

        public string Comment { get; set; }
        public int Rating { get; set; }

        [Display(Name = "Confirm Password")]
        public string ModPassword { get; set; }

        public DetailsViewModel(tblRecord record, List<tblRating> ratings)
        {
            Record = record;
            RatingsList = ratings;

            if (RatingsList.Count() >= 1) 
            {
                OverallRating = RatingsList.Select(x => x.Rating).Sum() / RatingsList.Count();
            }
            else
            {
                OverallRating = 0;
            }
        }

        public DetailsViewModel()
        {

        }
    }
}