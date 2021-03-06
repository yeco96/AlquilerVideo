﻿using AlquilerVideo.BD;
using AlquilerVideo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVideo.Controllers
{
    public class PeliculaController : Controller
    {
        private Datos datos = new Datos();

        // GET: Pelicula
        public ActionResult Index()
        {

            var _pelicula = datos.Pelicula;
            var peliculas = _pelicula.AsQueryable();

            return View(peliculas);
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pelicula/Create
        public ActionResult Insertar()
        {

            var _genero = datos.Genero;
            var generos = _genero.AsQueryable();


            List<SelectListItem> listaTitulos = new List<SelectListItem>();
            var _generos = generos.ToList();
            foreach (Genero genero in _generos)
            {
                listaTitulos.Add(new SelectListItem() { Text = genero.genero, Value = genero.genero });
            }
            SelectList mostrar = new SelectList(listaTitulos, "Value", "Text", 2);
            ViewBag.generos = mostrar;

            //ViewBag.generos = generos;
            ViewBag.calificacion = new SelectList(new List<Object> { new { value = "+4", text = "+4" }, new { value = "+13", text = "+13" }, new { value = "+16", text = "+16" }, new { value = "+18", text = "+18" } }, "value", "text", 2);
            return View();
        }

        // POST: Pelicula/Create
        [HttpPost]
        public ActionResult Insertar(Pelicula parmPelicula)
        {
            try
            {
                var pelicula = datos.Pelicula;
                pelicula.InsertOne(parmPelicula);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pelicula/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pelicula/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pelicula/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pelicula/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
