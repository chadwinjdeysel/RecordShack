using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Genre
{
    public class DeleteViewModel
    {
        public tblGenre Genre { get; set; }
        public List<tblRecord> RecordsList { get; set; }

        [Display(Name = "Confirm Password")]
        public string Password { get; set; }

        public DeleteViewModel(tblGenre genre, List<tblRecord> records)
        {
            Genre = genre;
            RecordsList = records.Where(x => x.GenreID == Genre.GenreID).ToList();
        }

        public DeleteViewModel()
        {

        }
    }
}