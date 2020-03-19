using RecordShack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordShack.View_Models.Record
{
    public class EditViewModel
    {
        public int RecordID { get; set; }

        [Required]
        [Display(Name = "Record Name")]
        public string RecordName { get; set; }

        [Required]
        [Display(Name = "Record Bio")]
        public string RecordBio { get; set; }

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
        public string ReleaseDate { get; set; }

        public EditViewModel()
        {
            RecordShackCMSEntities context = new RecordShackCMSEntities();

            List<SelectListItem> glist = new List<SelectListItem>();
            foreach (var item in context.tblGenres.ToList())
            {
                glist.Add(new SelectListItem()
                {
                    Text = item.GenreName,
                    Value = item.GenreID.ToString()
                });
            }

            Genre = glist;

            List<SelectListItem> alist = new List<SelectListItem>();
            foreach (var item in context.tblArtists.ToList())
            {
                alist.Add(new SelectListItem()
                {
                    Text = item.ArtistName,
                    Value = item.ArtistID.ToString()
                });
            }

            Artist = alist;
        }

        public EditViewModel(int id, string name, string bio, string imgsrc, string imgalt, string genreselected, string artistselected, DateTime releasedate)
        {
            RecordShackCMSEntities context = new RecordShackCMSEntities();

            List<SelectListItem> glist = new List<SelectListItem>();
            foreach (var item in context.tblGenres.ToList())
            {
                glist.Add(new SelectListItem()
                {
                    Text = item.GenreName,
                    Value = item.GenreID.ToString()
                });
            }

            Genre = glist;

            List<SelectListItem> alist = new List<SelectListItem>();
            foreach (var item in context.tblArtists.ToList())
            {
                alist.Add(new SelectListItem()
                {
                    Text = item.ArtistName,
                    Value = item.ArtistID.ToString()
                });
            }

            Artist = alist;

            RecordID = id;
            RecordName = name;
            RecordBio = bio;
            ImageSrc = imgsrc;
            ImageAlt = imgalt;
            GenreSelected = genreselected;
            ArtistSelected = artistselected;
            ReleaseDate = String.Format("{0:yyyy-MM-dd}", releasedate);
        }
    }
}