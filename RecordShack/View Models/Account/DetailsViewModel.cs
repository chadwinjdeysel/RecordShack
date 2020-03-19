using RecordShack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordShack.View_Models.Account
{
    public class DetailsViewModel
    {
        public tblUser User { get; set; }

        public List<tblRating> RatingsList { get; set; }

        public DetailsViewModel(int? id)
        {
            RecordShackCMSEntities context = new RecordShackCMSEntities();

            User = context.tblUsers.Find(id);
            RatingsList = context.tblRatings.Where(x => x.UserID == User.UserID).ToList();
        }

        public DetailsViewModel(string username)
        {
            RecordShackCMSEntities context = new RecordShackCMSEntities();

            User = context.tblUsers.Where(x => x.UserName.ToLower() == username.ToLower()).FirstOrDefault();
            RatingsList = context.tblRatings.Where(x => x.UserID == User.UserID).ToList();
        }

        public DetailsViewModel()
        {

        }
    }
}