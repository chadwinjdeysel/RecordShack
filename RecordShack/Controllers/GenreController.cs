using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;
using RecordShack.View_Models.Genre;

namespace RecordShack.Controllers
{
    public class GenreController : Controller
    {
        RecordShackCMSEntities context = new RecordShackCMSEntities();
        // GET: Genre

        public ActionResult GenreList()
        {
            var genres = context.tblGenres.ToList();
            return PartialView(@"~/Views/Shared/GenreListPartial.cshtml", genres);
        }

        public ActionResult Details(int? id)
        {
            if(id != null)
            {
                var genre = context.tblGenres.Find(id);
                var recordlist = context.tblRecords.ToList();
                DetailsViewModel detailsvm = new DetailsViewModel(genre, recordlist);
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
            AdminIndexViewModel indexVM = new AdminIndexViewModel(context.tblGenres.ToList());
            return View(indexVM);
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
            if(ModelState.IsValid)
            {
                string filename = Path.GetFileName(createvm.Image.FileName);
                createvm.ImageSrc = "~/Content/GenreImages/" + filename;
                filename = Path.Combine(Server.MapPath("~/Content/GenreImages/"), filename);
                createvm.Image.SaveAs(filename);

                tblGenre genre = new tblGenre(createvm.GenreName, createvm.GenreBio, createvm.ImageSrc, createvm.ImageAlt);
                context.tblGenres.Add(genre);
                context.SaveChanges();
                ModelState.Clear();

                return RedirectToAction("AdminIndex");
            }
            else
            {
                return View();
            }            
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                var genre = context.tblGenres.Find(id);
                var records = context.tblRecords.ToList();
                DeleteViewModel deletevm = new DeleteViewModel(genre, records);
                return View(deletevm);
            }
            else
            {
                return RedirectToAction("AdminIndex");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteViewModel view)
        {
            bool isPasswordValid = context.tblUsers
                                    .Any(x => x.UserName.ToLower() == User.Identity.Name.ToLower() &&
                                     x.Password == view.Password);

            if (isPasswordValid)
            {
                tblGenre genre = context.tblGenres.Find(view.Genre.GenreID);

                List<tblRecord> records = context.tblRecords.Where(x => x.ArtistID == genre.GenreID).ToList();
                foreach (var item in records)
                {
                    context.tblRecords.Remove(item);
                }

                context.tblGenres.Remove(genre);
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
                var genre = context.tblGenres.Find(id);
                EditViewModel editvm = new EditViewModel(genre.GenreID, genre.GenreName, genre.GenreBio, genre.ImageSrc, genre.ImageAlt);
                return View(editvm);
            }
            else
            {
                return RedirectToAction("AdminIndex");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreID, GenreName, GenreBio, ImageSrc, ImageAlt")]tblGenre genre)
        {
            if(ModelState.IsValid)
            {
                context.Entry(genre).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete()
        {
            return View();
        }
    }
}