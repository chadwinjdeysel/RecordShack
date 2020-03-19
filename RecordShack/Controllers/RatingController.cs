using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.View_Models.Record;
using RecordShack.Models;
using RecordShack.View_Models.Rating;

namespace RecordShack.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        RecordShackCMSEntities context = new RecordShackCMSEntities();
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRating(DetailsViewModel addratingvm)
        {
            if(ModelState.IsValid)
            {
                string username = User.Identity.Name;
                tblRating rating = new tblRating(addratingvm.Record.RecordID, addratingvm.Comment, addratingvm.Rating, username);
                context.tblRatings.Add(rating);
                context.SaveChanges();
                return RedirectToAction("Details", "Record", new { id = addratingvm.Record.RecordID });
            }
            else
            {
                return RedirectToAction("Details", "Record", new { id = addratingvm.Record.RecordID });
            }
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult ModIndex()
        {
            ModIndexViewModel indexvm = new ModIndexViewModel(context.tblRatings.ToList());
            return View(indexvm);
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult Delete(int? id)
        {
            tblRating rating = context.tblRatings.Find(id);

            if(rating != null)
            {
                context.tblRatings.Remove(rating);
                context.SaveChanges();
            }

            return RedirectToAction("ModIndex");
        }
    }
}