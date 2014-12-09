using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using s00131154CA2MVCAPP.Models;
using s00131154CA2MVCAPP.Views.Shared;
using System.Net;
using System.Diagnostics;

namespace s00131154CA2MVCAPP.Controllers
{
    public class MovieController : Controller
    {
        MovieDb db = new MovieDb();

        //
        // GET: /Movie/

        public ActionResult Index(string sortOrder)
        {
            ViewBag.PageTitle  ="List of Movies (Total " + db.Movies.Count() + " Movies comprising " + db.Actors.Distinct().Count() + " known Actors)";
            if (sortOrder == null) sortOrder = "ascNumber";
            ViewBag.numberOrder = (sortOrder == "ascNumber") ? "descNumber" : "ascNumber";
            ViewBag.dateOrder = (sortOrder == "ascDate") ? "descDate" : "ascDate";

            IQueryable<Movie> movies = db.Movies;
            switch (sortOrder)
            {
                case "descDate":
                    ViewBag.dateOrder = "ascDate";
                    movies = movies.OrderByDescending(m => m.ReleaseDate).Include("MovieActors");
                    break;
                case "descNumber":
                    ViewBag.numberOrder = "ascNumber";
                    movies = movies.OrderByDescending(m => m.MovieActors.Count).Include("MovieActors");
                    break;
                case "ascDate":
                    ViewBag.dateOrder = "descDate";
                    movies = movies.OrderBy(m => m.ReleaseDate).Include(m => m.MovieActors);
                    break;
                case "ascNumber":
                    ViewBag.numberOrder = "descNumber";
                    movies = movies.OrderBy(m => m.MovieActors.Count).Include("MovieActors");
                    break;
                default:
                    ViewBag.numberOrder = "ascNumber";
                    movies = movies.OrderBy(m => m.MovieActors.Count).Include("MovieActors");
                    break;                    
            }

            /*this.AddToastMessage("My first message", "A lot of important text", ToastType.Success);*/
            var listOfMovies = movies.ToList();
            return View(listOfMovies);
        }

        //
        // GET: /Movie/Details/5

        public ActionResult Details(int? id )
        {            
            if (id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var q = db.Movies.Find(id); // if no worky, q == null
            if (q == null)  // find record?
            {
                Debug.WriteLine("Record not found");
                ViewBag.PageTitle = String.Format("Sorry, record {0} not found.", id);
                //return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            else ViewBag.PageTitle = "Details of " + q.Title + " (" + ((q.MovieActors.Count == 0) ? "None" : q.MovieActors.Count.ToString()) + ')';
            ViewBag.AgeStats = q.MovieActors.Count(actr => (actr.Actor.DoB.Year + 40) > DateTime.Now.Year).ToString() + ',' + q.MovieActors.Count(actr => (actr.Actor.DoB.Year + 40) < DateTime.Now.Year).ToString();
            return View(q);
            //havn't put anything into the associated view yet
        }

        public ActionResult DeadLink()
        {
            //ViewBag.moviesList = db.Movies.ToList();
            return View();
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
            ViewBag.moviesList = db.Movies.ToList();
            return View();
        }

        //
        // POST: /Movie/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie newMovie)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db1 = new MovieDb())
                    {
                        db1.Movies.Add(newMovie);
                        db1.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Movie/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.leadersList = db.Actors.ToList();
            return View(db.Movies.Find(id));
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie editMovie)
        {
            
            try
            {
                // Find the record in the db using the camp ID
                // Copy the edited one across to the retrieved one
                // Save back to database
                db.Entry(editMovie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Movie/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Movie/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
    
}