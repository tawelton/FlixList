using Microsoft.AspNet.Identity;
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

        public ActionResult EditMovie(int movieID)
        {
            Movie movie = db.Movies.FirstOrDefault(m => m.movieID == movieID);

            if (movie == null)
            {
                RedirectToAction("Index");
            }

            List<Location> locations = db.Locations.ToList();
            string userId = User.Identity.GetUserId();

            List<int> userLocationIds = db.Database.SqlQuery<int>("SELECT locationID FROM UserLibrary WHERE userID = '" + userId + "' AND movieID = '" + movieID + "';").ToList();

            foreach (Location l in locations)
            {
                if (userLocationIds.Contains(l.locationID))
                {
                    l.selected = true;
                }
            }
            UserMovie UserMovieModel = new UserMovie(movie, locations);


            return View(UserMovieModel);
        }

        [HttpPost]
        public ActionResult EditMovie(UserMovie model)
        {
            string currentUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                foreach (Location l in model.locations)
                {
                    if (!l.selected)
                    {
                        var itemToRemove = db.UserLibraries.FirstOrDefault(ul => ul.userID == currentUser && ul.movieID == model.movie.movieID && ul.locationID == l.locationID);
                        if (itemToRemove != null)
                        {
                            db.UserLibraries.Remove(itemToRemove);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        UserLibrary itemToAdd = new UserLibrary() { userID = currentUser, locationID = l.locationID, movieID = model.movie.movieID };

                        db.UserLibraries.Add(itemToAdd);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("MyLibrary");
            }
            else
            {
                return View(model.movie.movieID);
            }
            
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

            selectedUserMovie.locations = new List<Location>();
            selectedUserMovie.movie = retrievedMovie;

            string currentUserID = User.Identity.GetUserId();

            List<UserLibrary> userMovieLocations = db.UserLibraries.Where(library => library.userID == currentUserID).ToList();

            foreach(UserLibrary userMovie in userMovieLocations)
            {
                Location retrievedLocation = db.Locations.Find(userMovie.locationID);

                selectedUserMovie.locations.Add(retrievedLocation);
            }


            return View(selectedUserMovie);
        }

        [HttpPost]
        public ActionResult MyMovieDetails(UserMovie movieToRemove)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM UserLibrary WHERE movieID = '" + movieToRemove.movie.movieID + "' AND userID = '" + User.Identity.GetUserId() + "';");

            return RedirectToAction("MyLibrary");
        }
    }
}