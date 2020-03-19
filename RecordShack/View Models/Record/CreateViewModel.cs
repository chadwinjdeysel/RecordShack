using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Record
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name = "Record Name")]
        public string RecordName { get; set; }

        [Required]
        [Display(Name = "Record Bio")]
        public string RecordBio { get; set; }

        [Required]
        public HttpPostedFileBase Image { get; set; }

        public string ImageSrc { get; set; }

        [Required]
        [Display(Name = "Image Alt")]
        public string ImageAlt { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string GenreSelected { get; set; }
        public IEnumerable<SelectListItem> Genre { get; set; }

        [Required]
        [Display(Name = "Artist")]
        public string ArtistSelected { get; set; }
        public IEnumerable<SelectListItem> Artist { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        public CreateViewModel()
        {
            RecordShackCMSEntities context = new RecordShackCMSEntities();

            List<SelectListItem> glist = new List<SelectListItem>();
            foreach(var item in context.tblGenres.ToList())
            {
                glist.Add(new SelectListItem()
                {
                    Text = item.GenreName,
                    Value = item.GenreID.ToString()
                });
            }

            Genre = glist;

            List<SelectListItem> alist = new List<SelectListItem>();
            foreach(var item in context.tblArtists.ToList())
            {
                alist.Add(new SelectListItem()
                {
                    Text = item.ArtistName,
                    Value = item.ArtistID.ToString()
                });
            }

            Artist = alist;
        }
    }
}