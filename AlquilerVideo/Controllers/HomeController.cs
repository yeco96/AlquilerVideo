using AlquilerVideo.BD;
using AlquilerVideo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVideo.Controllers
{
    public class HomeController : Controller
    {
        private Datos datos = new Datos();
        List<Pelicula> pelis = new List<Pelicula>();

        // GET: Pelicula
        public ActionResult Index()
        {

            var _alquiler = datos.Transaccion;
            var alquileres = _alquiler.AsQueryable();

            return View(alquileres);
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pelicula/Create
        public ActionResult Insertar()
        {
            pelis = datos.Pelicula.Find(e => true).ToList();
            var _pelicula = datos.Pelicula;
            var peliculas = _pelicula.AsQueryable();
            //ViewBag.generos = generos;
            ViewBag.peliculas = new SelectList(pelis);
            return View();
        }

        // POST: Pelicula/Create
        [HttpPost]
        public ActionResult Insertar(Transaccion parmTransaccion)
        {
            try
            {
                var transaccion = datos.Transaccion;
                transaccion.InsertOne(parmTransaccion);
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