using RecordShack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecordShack.View_Models.Record
{
    public class DeleteViewModel
    {
        public tblRecord Record { get; set; }

        public List<tblRating> RatingsList { get; set; }

        [Display(Name = "Confirm Password")]
        public string Password { get; set; }

        public DeleteViewModel(tblRecord record, List<tblRating> ratings)
        {
            Record = record;
            RatingsList = ratings.Where(x => x.RecordID == Record.RecordID).ToList();
        }

        public DeleteViewModel()
        {

        }

    }
}