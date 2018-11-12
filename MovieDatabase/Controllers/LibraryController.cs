using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieDatabase.Controllers
{
    public class LibraryController : Controller
    {
        // GET: MyLibrary
        public ActionResult MyLibrary()
        {
            return View();
        }
    }
}