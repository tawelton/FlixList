﻿using Microsoft.AspNet.Identity;
using MovieDatabase.DAL;
using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieDatabase.Controllers
{
    [Authorize]
    public class LibraryController : Controller
    {
        private FlixListContext db = new FlixListContext();

        // GET: MyLibrary
        public ActionResult MyLibrary()
        {
            
            List<Movie> userLibrary = new List<Movie>();

            string userLibraryQuery = "SELECT * FROM Movie WHERE MovieID IN(SELECT DISTINCT MovieID FROM UserLibrary WHERE UserID = '" + User.Identity.GetUserId() + "'); ";

            userLibrary = db.Database.SqlQuery<Movie>(userLibraryQuery).ToList();

            return View(userLibrary);
        }

        public ActionResult MyMovieDetails(string movieID)
        {
            int movieIDParsed = int.TryParse(movieID, out movieIDParsed) ? movieIDParsed : -1;

            if (movieIDParsed == -1)
            {
                return RedirectToAction("MyLibrary", new { movieID = movieID });
            }


            if (movieID == null)
            {
                return RedirectToAction("MyLibrary");
            }

            Movie retrievedMovie = db.Movies.Find(movieIDParsed);

            if (retrievedMovie == null)
            {
                return RedirectToAction("MyLibrary");
            }

            UserMovie selectedUserMovie = new UserMovie();

            selectedUserMovie.movie = retrievedMovie;

            string currentUserID = User.Identity.GetUserId();

            List<UserLibrary> userMovieLocations = db.UserLibraries.Where(library => library.userID == currentUserID).ToList();

            foreach(UserLibrary userMovie in userMovieLocations)
            {
                selectedUserMovie.locations.Add(db.Locations.Find(userMovie.locationID));
            }


            return View();
        }
    }
}