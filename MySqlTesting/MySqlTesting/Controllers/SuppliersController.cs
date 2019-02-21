using MySqlTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MySqlTesting.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult Index()
        {
            List<Supplier> list = new List<Supplier>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                list = context.Suppliers.ToList<Supplier>();
            }
                return View(list);
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            Supplier supplier = new Supplier();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                supplier = context.Suppliers.Where(x => x.Id == id).FirstOrDefault();
            }
                return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View(new Supplier());
        }

        // POST: Suppliers/Create
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            Supplier supplier = new Supplier();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                supplier = context.Suppliers.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            Supplier supplier = new Supplier();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                supplier = context.Suppliers.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Supplier supplier = context.Suppliers.Where(x => x.Id == id).FirstOrDefault();
                context.Suppliers.Remove(supplier);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
