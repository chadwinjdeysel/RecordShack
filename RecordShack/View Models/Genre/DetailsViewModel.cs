using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Genre
{
    public class DetailsViewModel
    {
        public tblGenre Genre { get; set; }
        public List<tblRecord> RecordsList { get; set; }

        public DetailsViewModel(tblGenre genre, List<tblRecord> recordslist)
        {
            Genre = genre;
            RecordsList = recordslist.Where(x => x.GenreID == Genre.GenreID).Take(3).ToList();
        }
    }
}