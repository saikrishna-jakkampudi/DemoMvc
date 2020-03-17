using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMvc.Models;

namespace DemoMvc.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Update

        static List<EMPDATA> EL = null;

        static List<DEPTDATA> DL = null;
        public ActionResult EmpUpdate()
        {
                return View();
       }
       public ActionResult EmpnoUpdate()
       {
                int empno = int.Parse(Request.QueryString["empno"]);
                EMPDATA emp = UpdateOperations.GetEmpupdate(empno);
                return View("EmpUpdate", emp);
       }
        [HttpPost]
       public ActionResult ButtonUpdateEmp(EMPDATA E)
       {
            string m = UpdateOperations.GetEmpnoData(E);
            ViewBag.res = m;
            return View("EmpUpdate");
        
       }

        public ActionResult EmpHireDate()
        {
                return View();
        }

        public ActionResult EmpHdDate()
        {
            DateTime sd = DateTime.Parse(Request.Form["txtStartDate"]);
            DateTime ed = DateTime.Parse(Request.Form["txtEndDate"]);
            EL = UpdateOperations.GetHdDate(sd,ed);
            return View("EmpHireDate",EL);
        }
        public ActionResult EmpDeptnoDate()
        {
            DL = UpdateOperations.getDepts();
            ViewBag.DL = DL;
            return View();
        }
        public ActionResult EmpDeptnoSubmit()
        {
            string value = Request.Form["rdbHdDeptno"];
            DL = UpdateOperations.getDepts();
            ViewBag.DL = DL;
            if (value == "hiredate")
            {
                DateTime sdate = DateTime.Parse(Request.Form["txtStartDate"]);
                DateTime edate = DateTime.Parse(Request.Form["txtEndDate"]);
                EL = UpdateOperations.GetHdDate(sdate, edate);
                return View("EmpDeptnoDate", EL);
            }
            else if (value == "deptno")
            {
                int deptno = int.Parse(Request.Form["ddlDeptno"]);
                List<EMPDATA> L = DBOperations.GetDept(deptno);
                ViewBag.Dept = deptno;
                return View("EmpDeptnoDate", L);
            }
            return View("EmpDeptnoDate");
        }
        public ActionResult AllEmpData()
        {
            EL = UpdateOperations.EmpData();
            return View(EL);
        }
        public ActionResult GetAllEmpData()
        {
            int empno = Convert.ToInt32(Request.Form["RadioButton"].ToString());
            EMPDATA emp = UpdateOperations.GetEmpupdata(empno);
            return View(emp);
        }
        public ActionResult SelEmpData()
        {
            EL = UpdateOperations.EmpData();
            return View(EL);
        }
        public ActionResult GetSelEmpData()
        {
            var empno = Request.Form.Get("CheckBox");
            EL = UpdateOperations.EmpData();
            List<EMPDATA> FL = new List<EMPDATA>();
            foreach (var e in EL)
            {
                if (empno.Contains(e.EMPNO.ToString()))
                {
                    FL.Add(e);
                }
            }
            return View(FL);
        }
    }
}