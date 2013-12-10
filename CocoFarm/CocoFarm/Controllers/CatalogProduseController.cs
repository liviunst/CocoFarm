﻿using System;
using CocoFarm.DataAccess;
using CocoFarm.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CocoFarm.Controllers
{
    public class CatalogProduseController : Controller
    {
        private readonly IDataStore<Produs, Guid> store;
        public CatalogProduseController(IDataStore<Produs, Guid> store)
        {
            this.store = store;
        }

        public ActionResult Index()
        {
            IEnumerable<Produs> produse = store.GetAll();
            return View(produse);
        }

        public ActionResult Details(Guid id)
        {
            var produs = store.GetById(id);
            return View(produs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produs produs)
        {
            try
            {
                store.Create(produs);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            var produs = store.GetById(id);
            return View(produs);
        }

        [HttpPost]
        public ActionResult Edit(Produs produs)
        {
            try
            {
                store.Update(produs);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produs);
            }
        }

        public ActionResult Delete(Guid id)
        {
            var produs = store.GetById(id);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Produs produs)
        {
            try
            {
                store.Delete(produs.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
