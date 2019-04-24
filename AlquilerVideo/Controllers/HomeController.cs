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
        //        private static List<Pelicula> detalle = new List<Pelicula>();

        // GET: Pelicula
        public ActionResult Transacciones()
        {

            var _alquiler = datos.Transaccion;
            var alquileres = _alquiler.AsQueryable();

            return View(alquileres);
        }
        public ActionResult LasPeliculas(string id)
        {
            var transacciones = datos.Transaccion;
            //var filter = Builders<Animales>.Filter.Eq(x => x._id, id);

            var laTransaccion = transacciones.Find<Transaccion>(a => a._id == id).FirstOrDefault();
            return View(laTransaccion.detallePelicula);
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pelicula/Create
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            var trans = datos.Transaccion;
            var lasTransacciones = trans.AsQueryable();


            if (!String.IsNullOrEmpty(searchString))
            {
                lasTransacciones = lasTransacciones.Where(s => s.tipoMovimiento.ToUpper().Contains(searchString.ToUpper()) ||
                                                     s.fechaTransaccion.Equals(DateTime.Parse(searchString)));
            }
            List < Pelicula > listaPeliculas = datos.Pelicula.Find(e => true).ToList();
            var _pelicula = datos.Pelicula;
            var peliculas = _pelicula.AsQueryable();
            if(TempData["detallePelicula"] == null)
            {
                ViewBag.peliculasList = new List<Pelicula>();
            }
            else
            {
                ViewBag.peliculasList = TempData["detallePelicula"];
            }


            List<SelectListItem> listaTitulos = new List<SelectListItem>();
            foreach (Pelicula pelicula in listaPeliculas)
            {
                listaTitulos.Add(new SelectListItem() { Text = pelicula.titulo, Value = pelicula._id});
            }

            ViewData["fechaActual"] = DateTime.Now.ToString();
            SelectList mostrar = new SelectList(listaTitulos, "Value", "Text", 2);
            ViewBag.peliculas = mostrar;
            return View(transacciones2.ToPagedList(pageNumber, pageSize));
        }

        // POST: Pelicula/Create
        [HttpPost]
        public ActionResult Index(Transaccion parmTransaccion)
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
        public ActionResult AgregarDetalle(Transaccion collection)
        {
            try
            {
                List<Pelicula> Peliculas = new List<Pelicula>();


                var _pelicula = datos.Pelicula;
                var peliculas = _pelicula.AsQueryable();
                var laPelicuala = _pelicula.Find<Pelicula>(a => a._id == collection.tempPelicula).FirstOrDefault();
                
                
                //TempData["detallePelicula"] = peliculas.ToList();

                if(TempData["detallePelicula"] == null)
                {
                    TempData["detallePelicula"] = Peliculas;
                }
               
                Peliculas = (List<Pelicula>) TempData["detallePelicula"];

                Peliculas.Add(laPelicuala);
                TempData["detallePelicula"] = Peliculas;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Pelicula/Edit/5
        [HttpPost]
        public ActionResult AgregarDetalle(string collection)
        {
            try
            {
            
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
        public ActionResult borrarDetalle()
        {
            try
            {
                TempData["detallePelicula"] = new List<Pelicula>();
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