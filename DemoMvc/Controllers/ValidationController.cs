using DemoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMvc.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Validations V)
        {
            return View();
        }
        public ActionResult GetBack(Validations VS)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("AddPage");
            }
            return View("Index");
        }
        public ActionResult AddPage()
        {
            return View();
        }
    }
}