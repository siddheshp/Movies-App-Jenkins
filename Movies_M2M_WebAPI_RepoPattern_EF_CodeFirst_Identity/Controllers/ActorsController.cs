﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_EF_Identity.Data;

namespace MVC_EF_Identity.Controllers
{
    public class ActorsController : Controller
    {
        IRepository _repository = null;
        public ActorsController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Actors
        public ActionResult Index()
        {
            return View(_repository.GetActors());
        }

        // GET: Actors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Actors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Actors/Delete/5
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