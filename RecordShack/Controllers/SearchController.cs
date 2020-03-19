using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;
using RecordShack.View_Models.Search;

namespace RecordShack.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult GlobalSearchPartial()
        {
            return PartialView(@"~/Views/Shared/GlobalSearchPartial.cshtml");
        }

        [HttpPost]
        public ActionResult GlobalSearchResults(GlobalSearchViewModel view)
        {
            GlobalSearchViewModel globalSearchvm = new GlobalSearchViewModel(view.SearchTerm);

            return View(globalSearchvm);
        }
    }
}