using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;
using RecordShack.View_Models.Artist;

namespace RecordShack.Controllers
{
    public class ArtistController : Controller
    {
        RecordShackCMSEntities context = new RecordShackCMSEntities();
        // GET: Artist
        public ActionResult Details(int? id)
        {
            if(id != null)
            {
                var artist = context.tblArtists.Find(id);
                var recordslist = context.tblRecords.ToList();
                DetailsViewModel detailsvm = new DetailsViewModel(artist, recordslist);
                return View(detailsvm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminIndex()
        {
            AdminIndexViewModel indexvm = new AdminIndexViewModel(context.tblArtists.ToList());
            return View(indexvm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel createvm)
        {

            if (ModelState.IsValid)
            {
                string filename = Path.GetFileName(createvm.Image.FileName);
                createvm.ImageSrc = "~/Content/ArtistImages/" + filename;
                filename = Path.Combine(Server.MapPath("~/Content/ArtistImages/"), filename);
                createvm.Image.SaveAs(filename);

                tblArtist artist = new tblArtist(createvm.ArtistName, createvm.ArtistBio, createvm.ImageSrc, createvm.ImageAlt);
                context.tblArtists.Add(artist);
                context.SaveChanges();
                ModelState.Clear();

                return View();
            }
            else
            {
                return View();
            }
            
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                var artist = context.tblArtists.Find(id);
                var records = context.tblRecords.ToList();
                DeleteViewModel deletevm = new DeleteViewModel(artist, records);
                return View(deletevm);
            }
            else
            {
                return RedirectToAction("AdminIndex");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(DeleteViewModel view)
        {
            bool isPasswordValid = context.tblUsers
                                    .Any(x => x.UserName.ToLower() == User.Identity.Name.ToLower() &&
                                     x.Password == view.Password);

            if(isPasswordValid)
            {
                tblArtist artist = context.tblArtists.Find(view.Artist.ArtistID);
                
                List<tblRecord> records = context.tblRecords.Where(x => x.ArtistID == artist.ArtistID).ToList();
                foreach(var item in records)
                {
                    context.tblRecords.Remove(item);
                }

                context.tblArtists.Remove(artist);
                context.SaveChanges();
                return RedirectToAction("AdminIndex");
            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if(id != null)
            {
                var artist = context.tblArtists.Find(id);
                EditViewModel editvm = new EditViewModel(artist.ArtistID, artist.ArtistName, artist.ArtistBio, artist.ImageSrc, artist.ImageAlt);
                return View(editvm);
            }
            else
            {
                return RedirectToAction("AdminIndex");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ArtistID, ArtistName, ArtistBio, ImageSrc, ImageAlt")]tblArtist artist)
        {
            if(ModelState.IsValid)
            {
                context.Entry(artist).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            else
            {
                return View(artist);
            }
        }
    }
}