using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Search
{
    public class GlobalSearchViewModel
    {
        [Display(Name = "Results for Artists")]
        public List<tblArtist> ArtistList { get; set; }

        [Display(Name = "Results for Genres")]
        public List<tblGenre> GenreList { get; set; }

        [Display(Name = "Results for Records")]
        public List<tblRecord> RecordList { get; set; }

        public string SearchTerm { get; set; }

        public GlobalSearchViewModel()
        {

        }

        public GlobalSearchViewModel(string searchterm)
        {
            SearchTerm = searchterm;
            RecordShackCMSEntities context = new RecordShackCMSEntities();

            ArtistList = context.tblArtists.Where(x => x.ArtistName.Contains(SearchTerm)).ToList();
            GenreList = context.tblGenres.Where(x => x.GenreName.Contains(SearchTerm)).ToList();
            RecordList = context.tblRecords.Where(x => x.RecordName.Contains(SearchTerm)).ToList();  
        }

    }
}