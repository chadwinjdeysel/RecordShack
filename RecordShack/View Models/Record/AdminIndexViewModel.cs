using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Record
{
    public class AdminIndexViewModel
    {
        [Display(Name = "Image")]
        public string ImageSrc { get; set; }

        [Display(Name = "Name")]
        public string RecordName { get; set; }

        [Display(Name = "Record Bio")]
        public string RecordBio { get; set; }

        public List<tblRecord> RecordsList { get; set; }

        public AdminIndexViewModel()
        {

        }

        public AdminIndexViewModel(List<tblRecord> records)
        {
            RecordsList = records;
        }

    }
}