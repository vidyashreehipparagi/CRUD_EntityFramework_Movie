using CRUD_EntityFramework_Movie.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_EntityFramework_Movie.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext context;
        MovieCrud crud;

        public MovieController(ApplicationDbContext context)
        {
            this.context = context;
            crud=new MovieCrud(this.context);
        }

        // GET: MovieController
        public ActionResult Index()
        {
            
            return View(crud.GetAllMovies());
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View(crud.GetMovieById(id));
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                int result=crud.AddMovie(movie);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = crud.GetMovieById(id);
            return View(result);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                int result=crud.UpdateMovie(movie);
                if(result==1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {


            var result = crud.GetMovieById(id);
            return View(result);
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteMovie(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else return View();


            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
