using RecordShack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordShack.View_Models.Rating
{
    public class ModIndexViewModel
    {
        public List<tblRating> RatingsList { get; set; }

        public ModIndexViewModel(List<tblRating> ratings)
        {
            RatingsList = ratings.OrderByDescending(x => x.RatingID).ToList();
        }

        public ModIndexViewModel()
        {

        }
    }
}