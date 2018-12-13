using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class HomeController : Controller
    {
        //Sample data for the Movies view
        public static List<Movie> movies = new List<Movie>{
            new Movie(
                "Jaws", 
                "2:04", 
                "https://m.media-amazon.com/images/M/MV5BMmVmODY1MzEtYTMwZC00MzNhLWFkNDMtZjAwM2EwODUxZTA5XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_SX651_CR0,0,651,999_AL_.jpg"
                ),
            new Movie(
                "Ferris Bueller's Day Off",
                "1:43",
                "https://m.media-amazon.com/images/M/MV5BMDA0NjZhZWUtNmI2NC00MmFjLTgwZDYtYzVjZmNhMDVmOTBkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg"
                ),
            new Movie(
                "The Shawshank Redemption",
                "2:22",
                "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"
                ),
            new Movie(
                "The Godfather",
                "2:55",
                "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg"
                ),
            new Movie(
                "The Dark Knight",
                "2:32",
                "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg"
                ),
            new Movie(
                "Schindler's List",
                "3:15",
                "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,666,1000_AL_.jpg"
                ),
            new Movie(
                "Forrest Gump",
                "2:22",
                "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg"
                ),
            new Movie(
                "Inception",
                "2:28",
                "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg"
                ),
            new Movie(
                "The Matrix",
                "2:16",
                "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,665,1000_AL_.jpg"
                ),
            new Movie(
                "Life is Beautiful",
                "1:56",
                "https://m.media-amazon.com/images/M/MV5BYmJmM2Q4NmMtYThmNC00ZjRlLWEyZmItZTIwOTBlZDQ3NTQ1XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_SX670_AL_.jpg"
                ),
            new Movie(
                "Spirited Away",
                "2:05",
                "https://m.media-amazon.com/images/M/MV5BOGJjNzZmMmUtMjljNC00ZjU5LWJiODQtZmEzZTU0MjBlNzgxL2ltYWdlXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_SY1000_CR0,0,675,1000_AL_.jpg"
                ),
            new Movie(
                "Interstellar",
                "2:49",
                "https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_SX675_AL_.jpg"
                ),

        };

        public ActionResult Movies(string search)
        {
            // check if no search criteria
            if (search == null)
            {
                return View(movies);
            }

            //return list of movies matching search result
            List<Movie> searchResults = movies.FindAll(movie => movie.title.ToUpper().Contains(search.ToUpper()));
            return View(searchResults);
        }

        public ActionResult MovieDetails(string movieID)
        {
            // convert the movieID string to an integer
            int movieIDParsed = int.TryParse(movieID, out movieIDParsed) ? movieIDParsed: -1;

            if (movieIDParsed == -1)
            {
                return RedirectToAction("Movies", new { movieID = movieID});
            }
            
            // check if movieID is passed and redirect to movies view if none
            if (movieID == null)
            {
                return RedirectToAction("Movies");
            }

            // check if movie is in list of movies
            Movie selectedMovie = movies.Find(movie => movie.movieID == movieIDParsed);

            // redirect to movies view if movie not found
            if (selectedMovie == null)
            {
                return RedirectToAction("Movies");
            }

            return View(selectedMovie);
        }

        public ActionResult Contact()
        {
            // will use this method in the future
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}