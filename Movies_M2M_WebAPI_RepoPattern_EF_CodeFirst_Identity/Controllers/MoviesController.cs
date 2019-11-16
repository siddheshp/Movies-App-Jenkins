using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EF_Identity.Data;
using MVC_EF_Identity.Models;
using MVC_EF_Identity.ViewModels;

namespace MVC_EF_Identity.Controllers
{
    public class MoviesController : Controller
    {
        IRepository _repository = null;
        public MoviesController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Movies
        public ActionResult Index()
        {
            return View(_repository.GetMovies());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var moviewViewModdel = new MovieViewModel
            {
                Actors = _repository.GetActors().Select(a =>
                           new SelectListItem(a.Name, a.Id.ToString())).ToList()
            };
            return View(moviewViewModdel);
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel viewModel) //IFormCollection collection
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = _repository.AddMovie(viewModel);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        viewModel.Actors = _repository.GetActors().Select(a =>
                                                new SelectListItem(a.Name, a.Id.ToString())).ToList();
                        return View(viewModel);
                    }
                }
                viewModel.Actors = _repository.GetActors().Select(a =>
                                                new SelectListItem(a.Name, a.Id.ToString())).ToList();
                return View(viewModel);
            }
            catch
            {
                viewModel.Actors = _repository.GetActors().Select(a =>
                                                new SelectListItem(a.Name, a.Id.ToString())).ToList();
                return View(viewModel);
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = _repository.GetMovieById(id);
            var movieVM = new MovieViewModel
            {
                Movie = movie,
                Actors = movie.MovieActors.Select(ma =>
                            new SelectListItem(ma.Actor.Name, ma.ActorId.ToString())).ToList()
            };
            return View(movieVM);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieViewModel viewModel)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}