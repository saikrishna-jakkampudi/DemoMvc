using DemoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMvc.Controllers
{
    public class DemoController : Controller
    {

        // GET: Demo
        public ActionResult Index()
        {
            ViewBag.str = "My First MVC Project";
            ViewData["str1"] = "My First Project";
            TempData["str2"] = "My Project";
            return View();
        }
        public ActionResult SendObject()
        {
            Emp E = new Emp();
            E.Empno = 99999;
            E.Ename = "Vishal Reddy";
            E.Salary = 338000;
            return View(E);
        }
        public ActionResult SendObjects()
        {
            List<Emp> elist = new List<Emp>();
            Emp E = null;
            E = new Emp();
            E.Empno = 1;
            E.Ename = "QWERTY";
            E.Salary = 7897987;
            elist.Add(E);
            E = new Emp();
            E.Empno = 2;
            E.Ename = "ASDFG";
            E.Salary = 134555;
            elist.Add(E);
            return View(elist);
        }
        public ActionResult SendObjectVB()
        {
            Emp E = null;
            E = new Emp();
            E.Empno = 2;
            E.Ename = "ftghvng";
            E.Salary = 4651351;
            ViewBag.emp = E;
            ViewData["xyz"] = E;
            return View();
        }
        public ActionResult SendObjectsVB()
        {
            List<Emp> elist = new List<Emp>();
            Emp E = null;
            E = new Emp();
            E.Empno = 1;
            E.Ename = "QWERTY";
            E.Salary = 7897987;
            elist.Add(E);
            E = new Emp();
            E.Empno = 2;
            E.Ename = "ASDFG";
            E.Salary = 134555;
            elist.Add(E);
            ViewBag.xyz = elist;
            ViewData["abc"] = elist;
            return View();
        }
    }
}
