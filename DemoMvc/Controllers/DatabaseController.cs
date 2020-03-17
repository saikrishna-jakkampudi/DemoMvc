using DemoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMvc.Controllers
{
    
    public class DatabaseController : Controller
    {
        // GET: Database

        static List<DEPTDATA> DL = null;

        static List<EMPDATA> EL = null;
        public ActionResult Index()
        {
            EMPDATA E =new EMPDATA();
            return View(E);
        }
        [HttpPost]
        public ActionResult Index(EMPDATA E)
        {
           ViewBag.msg= DBOperations.InsertEmp(E);
            return View();
        }
            
        public ActionResult getDeptData()
        {
            return View();
        }
        public ActionResult GetDept()
        {
           
            int deptno = int.Parse(Request.Form["txtDeptno"]);
            List<EMPDATA> L= DBOperations.GetDept(deptno);
            return View("GetDeptData",L);
        }
        public ActionResult GetEmpData()
        {
            return View();
        }
        public ActionResult getDepts()
        {
            
            DL=DBOperations.getDepts();
            ViewBag.S = DL;
            return View();
        }
        public ActionResult SendDept()
        {
            int deptno = int.Parse(Request.QueryString["d"]);
            ViewBag.S = DL;
            ViewBag.J = deptno;
            List<EMPDATA> E=DBOperations.GetDept(deptno);
            return View("getDepts",E);
        }

        public ActionResult empdel()
        {
            EL = DBOperations.empdel1();
            ViewBag.G = EL;
            return View();
        }

        public ActionResult EmployeeDel()
        {
            int Empno = int.Parse(Request.Form["ddlEmpno"]);
            ViewBag.S = EL;
            string A = DBOperations.empdelete(Empno);
            ViewBag.G = DBOperations.empdel1();
            ViewBag.res = A;
            return View("empdel");
        }
    }
}