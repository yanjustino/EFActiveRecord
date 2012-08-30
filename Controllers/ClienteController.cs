using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using d2d.Models;

namespace d2d.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            var clientes = new Cliente().All();
            return View(clientes);
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id)
        {
            var cliente = new Cliente().Find(id);
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, Cliente cliente)
        {
            try
            {
                // TODO: Add insert logic here
                cliente.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id)
        {
            var cliente = new Cliente().Find(id);
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        public ActionResult Edit(Cliente cliente, FormCollection collection)
        {
            try
            {
                cliente.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id)
        {
            var cliente = new Cliente().Find(id);
            return View(cliente);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost]
        public ActionResult Delete(Cliente cliente, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                cliente.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
