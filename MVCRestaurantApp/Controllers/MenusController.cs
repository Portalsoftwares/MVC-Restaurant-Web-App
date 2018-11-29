using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCRestaurantApp.Models;

namespace MVCRestaurantApp.Controllers
{   [Authorize]
    public class MenusController : Controller
    {
        private MenuMock db;

        public MenusController()
        {
            // if nothing passed to constructor, connect to the db (this is the default)
            this.db = new EFMenus();
        }

        public MenusController(MenuMock menuMock)
        {
            // if we pass a mock object to the constructor, we are unit testing so no db
            this.db = menuMock;
        }

        // GET: Menus
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("Index", db.Menus.ToList());
        }

        [AllowAnonymous]
        // GET: Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Menu menu = db.Menus.SingleOrDefault(a => a.Menu_Id == id);
            if (menu == null)
            {
                return View("Error");
            }
            return View("Details", menu);
        }

        // GET: Menus/Create
        public ActionResult Create() 
        {
           
            return View("Create");
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Menu_Id,Meal_Name,Meal_Type,Calories,Price")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Save(menu);
                return RedirectToAction("Index");
            }

            return View("Create", menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Menu menu = db.Menus.SingleOrDefault(a => a.Menu_Id == id);
            if (menu == null)
            {
                return View("Error");
            }
            return View("Edit", menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Menu_Id,Meal_Name,Meal_Type,Calories,Price")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Menu menu = db.Menus.SingleOrDefault(a => a.Menu_Id == id);
            if (menu == null)
            {
                return View("Error");
            }
            return View("Delete", menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            if (id == null)
            {
                return View("Error");
            }

            Menu menu = db.Menus.SingleOrDefault(a => a.Menu_Id == id);

            if (menu == null)
            {
                return View("Error");
            }

            db.Delete(menu);

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
