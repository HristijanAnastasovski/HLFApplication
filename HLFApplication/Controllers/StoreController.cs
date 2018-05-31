using HLFApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLFApplication.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Store
        public ActionResult Index()
        {
            Store model = new Store();
            model.ProteinsList = db.Proteins.OrderBy(p => p.Price).ToList();
            model.MultivitaminsList= db.Multivitamins.OrderBy(p => p.Price).ToList();
            model.AccessoriesList= db.Accessories.OrderBy(p => p.Price).ToList();
              
            return View(model);
        }
    }
}