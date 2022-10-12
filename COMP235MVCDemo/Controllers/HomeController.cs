using COMP235MVCDemo.DataAccessObjects;
using COMP235MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//site source: 
//https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/views/creating-custom-html-helpers-cs#:~:text=An%20HTML%20Helper%20is%20just,%3E%20and%20tags.
//what I've learned: how to apply custome HTML helpers within MVC to eliminate tedious html tags
//demonstration can be found in Movie.cshtml, AllMovies.cshtml, as I used HTML helpers to label the heading


//site source:
//https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller.redirecttoaction?view=aspnet-mvc-5.2
// what I've learned: how to redirect/refresh a page
//demonstration can be found under ActionResult AddMovie, DeleteAMovie, MovieDelete


namespace COMP235MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Movie(Movie movie, String Save)
        {
            ViewBag.Message = "My Movie Page.";
            MovieDAO dAO = new MovieDAO();
            if (Save == "Save")
            {
                //Movie movie = m.Item[m.EditIndex];
                dAO.updateMovie(movie);
                movie.IsEditable = false;
            }
            //set default display movie to movie with id 1
            movie = dAO.getMovieById(1);
            return View(movie);
        }

        public ActionResult AddMovie(Movie m, string Save) // each view need an Action Result Method to be viewed
        {
            ViewBag.Message = "Add A Movie Page";
            //Save is the name of the Value on the Button
            if (Save == "Save")
            {
                MovieDAO dAO = new MovieDAO();
                dAO.InsertMovie(m);
                ViewBag.Message = "Movie Added successfully";
                //clear out the the textboxes after a movie has been added by refreshing the page using RedirectToAction()
                return RedirectToAction("AddMovie");
            }
            return View("AddMovie");
        }

        public ActionResult AllMovies(Movies m, String Save)
        {
            ViewBag.Message = "All movies.";
            MovieDAO dAO = new MovieDAO();
            if (Save == "Save")
            {
                Movie movie = m.Items[m.EditIndex];
                dAO.updateMovie(movie);
                movie.IsEditable = false;
                m.EditIndex = -1;
            }
            m = dAO.getAllMovies();
            return View(m);
        }

        public ActionResult Details(Movie movie)
        {
            MovieDAO dAO = new MovieDAO();
            movie = dAO.getMovieById(movie.Id);
            return View("Movie", movie);
        }

        public ActionResult MoviesEdit(int? id, Movies movies)
        {
            int id2 = id ?? default(int);
            MovieDAO dAO = new MovieDAO();
            movies = dAO.getAllMovies();
            movies.EditIndex = dAO.setMovieToEditMode(movies.Items, id2);
            ViewBag.Message = "All movies.";
            return View("AllMovies", movies);
        }

        public ActionResult MovieDelete(Movie movie)
        {
            MovieDAO dAO = new MovieDAO();
            //movie = dAO.getMovieById(id);
            dAO.deleteMovie(movie.Id);
            return RedirectToAction("AllMovies");
        }
        public ActionResult EditAMovie(int? id, Movie movie)
        {
            int id2 = id ?? default(int);
            MovieDAO dAO = new MovieDAO();
            movie = dAO.getMovieById(id2);
            dAO.setAMovieToEditMode(movie, id2);
            ViewBag.Message = "Movie";
            return View("Movie", movie);
        }

        public ActionResult DeleteAMovie(Movie movie)
        {
            MovieDAO dAO = new MovieDAO();
            //movie = dAO.getMovieById(id);
            dAO.deleteMovie(movie.Id);
            return RedirectToAction("Movie");
        }
        

    }
    }