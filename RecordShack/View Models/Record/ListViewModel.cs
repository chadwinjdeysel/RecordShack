using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Record
{
    public class ListViewModel
    {
        public List<tblRecord> RecordsList { get; set; }

        public List<tblGenre> GenreList { get; set; }

        public int? GenreID { get; set; }

        
        // for sorting albums by genre
        public ListViewModel(int? id)
        {
            GenreID = id;
            RecordShackCMSEntities context = new RecordShackCMSEntities();
            GenreList = context.tblGenres.ToList();

            if (id != null)
            {
                RecordsList = context.tblRecords.Where(x => x.GenreID == id).ToList();
            }
            else
            {
                RecordsList = context.tblRecords.ToList();
            }
            
        }
    }
}