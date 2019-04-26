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
    public class ClienteController : Controller
    {
        private ContextoBD elContexto = new ContextoBD();

        public ActionResult LasPeliculas(string id)
        {
            var clientes = elContexto.LosClientes;

            var elCliente = clientes.Find<Cliente>(a => a._id == id).FirstOrDefault();
            return View(elCliente);
        }


        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = elContexto.LosClientes;
            var LosClientes = clientes.AsQueryable();
            return View(LosClientes);

        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Insertar()
        {
            var _cliente = elContexto.Cliente;
            var lclientes = _cliente.AsQueryable();;

            List<SelectListItem> listaClientes = new List<SelectListItem>();
            var _clientes = lclientes.ToList();
            foreach (Cliente cliente in _clientes)
            {
                listaClientes.Add(new SelectListItem() { Text = cliente.Nombre, Value = cliente.Nombre });
            }
            SelectList mostrar = new SelectList(listaClientes, "Value", "Text", 2);
            ViewBag.lclientes = mostrar;

            
           //ViewBag.calificacion = new SelectList(new List<Object> { new { value = "+4", text = "+4" }, new { value = "+13", text = "+13" }, new { value = "+16", text = "+16" }, new { value = "+18", text = "+18" } }, "value", "text", 2);
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Insertar(Cliente elCliente)
        {
            try
            {
                var clientes = elContexto.LosClientes;
                clientes.InsertOne(elCliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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
