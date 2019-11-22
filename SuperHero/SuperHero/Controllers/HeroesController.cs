using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class HeroesController : Controller
    {
        // GET: Heroes
        ApplicationDbContext db;
        public HeroesController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var listOfHeroes = db.Heroes.ToList();
            return View(listOfHeroes);
        }

        // GET: Heroes/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Heroes.Where(h => h.Id == id).FirstOrDefault());
        }

        // GET: People/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Heroes/Create
        [HttpPost]
        public ActionResult Create(Hero hero)
        {
            try
            {
                // TODO: Add insert logic here
                db.Heroes.Add(hero);
                db.SaveChanges();
                return RedirectToAction("Index", "Hero");
            }
            catch
            {
                return View();
            }
        }

        // GET: Heros/Edit/5
        public ActionResult Edit(int id)
        {
            Hero hero = db.Heroes.Where(h => h.Id == id).FirstOrDefault();
            return View(id);
        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Hero hero)
        {
            try
            {
                // TODO: Add update logic here
                Hero heroFromDb = db.Heroes.Where(h => h.Id == id).FirstOrDefault();
                heroFromDb.heroName = hero.heroName;
                heroFromDb.alterEgoName = hero.alterEgoName;
                heroFromDb.primaryAbility = hero.primaryAbility;
                heroFromDb.secondaryAbility = hero.secondaryAbility;
                heroFromDb.catchphrase = hero.catchphrase;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Hero hero)
        {
            try
            {
                // TODO: Add delete logic here

                db.Heroes.Remove(hero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
