using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;
using RecordShack.View_Models.Record;
using System.Web.Security;
using System.IO;
using System.Data.Entity;

namespace RecordShack.Controllers
{
    public class RecordController : Controller
    {
        RecordShackCMSEntities context = new RecordShackCMSEntities();
        // GET: Record
        [HttpGet]
        public ActionResult List(int? id)
        {
            ListViewModel listvm = new ListViewModel(id);
            return View(listvm);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id != null)
            {
                var record = context.tblRecords.Find(id);
                var ratings = context.tblRatings.Where(x => x.RecordID == id).ToList();

                DetailsViewModel detailsvm = new DetailsViewModel(record, ratings);
                
                return View(detailsvm);
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminIndex()
        {
            AdminIndexViewModel indexVM = new AdminIndexViewModel(context.tblRecords.ToList());
            return View(indexVM);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            CreateViewModel createvm = new CreateViewModel();
            return View(createvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateViewModel createvm)
        {
            if(ModelState.IsValid)
            {
                string filename = Path.GetFileName(createvm.Image.FileName);
                createvm.ImageSrc = "~/Content/RecordImages/" + filename;
                filename = Path.Combine(Server.MapPath("~/Content/RecordImages/"), filename);
                createvm.Image.SaveAs(filename);

                tblRecord record = new tblRecord(int.Parse(createvm.ArtistSelected), int.Parse(createvm.GenreSelected), createvm.RecordName, createvm.RecordBio, createvm.ReleaseDate, createvm.ImageSrc, createvm.ImageAlt);
                context.tblRecords.Add(record);
                context.SaveChanges();
                ModelState.Clear();

                CreateViewModel newcreatevm = new CreateViewModel();
                return View(newcreatevm);
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if(id != null)
            {
                var record = context.tblRecords.Find(id);
                EditViewModel editvm = new EditViewModel(record.RecordID, record.RecordName, record.RecordBio, record.ImageSrc, record.ImageAlt, record.GenreID.ToString(), record.ArtistID.ToString(), record.ReleaseDate.Value.Date);
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
        public ActionResult Edit([Bind(Include = "RecordID, RecordName, RecordBio, ReleaseDate, ArtistSelected, GenreSelected, ImageSrc, ImageAlt")]tblRecord record, EditViewModel view)
        {
            if(ModelState.IsValid)
            {
                record.ArtistID = int.Parse(view.ArtistSelected);
                record.GenreID = int.Parse(view.GenreSelected);
                context.Entry(record).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var record = context.tblRecords.Find(id);
                var ratings = context.tblRatings.ToList();
                DeleteViewModel deletevm = new DeleteViewModel(record, ratings);
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

            if (isPasswordValid)
            {
                tblRecord record = context.tblRecords.Find(view.Record.RecordID);

                List<tblRating> ratingslist = context.tblRatings.Where(x => x.RecordID == record.RecordID   ).ToList();
                foreach (var item in ratingslist)
                {
                    context.tblRatings.Remove(item);
                }

                context.tblRecords.Remove(record);
                context.SaveChanges();
                return RedirectToAction("AdminIndex");
            }

            return View();
        }
    }
}