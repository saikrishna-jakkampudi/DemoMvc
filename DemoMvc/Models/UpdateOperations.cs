using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMvc.Models
{
    public class UpdateOperations
    {
        static DemoEntities D = new DemoEntities();
        public static EMPDATA GetEmpupdate(int Empno)
        {
            var LE = from L in D.EMPDATAs
                     where L.EMPNO == Empno
                     select L;
            return LE.FirstOrDefault();
        }
        public static string GetEmpnoData(EMPDATA emp)
        {
            var LE = from L in D.EMPDATAs
                     where L.EMPNO == emp.EMPNO
                     select L;
            EMPDATA ED = LE.FirstOrDefault();
                ED.JOB = emp.JOB;
                ED.MGR = emp.MGR;
                ED.SAL = emp.SAL;
                ED.COMM = emp.COMM;
                ED.DEPTNO = emp.DEPTNO;
            
            D.SaveChanges();
            return "1 Row Updated";
        }
        public static List <EMPDATA> GetHdDate(DateTime StartDate,DateTime EndDate)
        {
            var LE = from L in D.EMPDATAs
                     where L.HIREDATE>= StartDate && L.HIREDATE<=EndDate
                     select L;
            return LE.ToList();
        }
        public static List<DEPTDATA> getDepts()
        {
            var dept = from D1 in D.DEPTDATAs
                       select D1;
            return dept.ToList();
        }
        public static EMPDATA GetEmpupdata(int Empno)
        {
            var LE = from L in D.EMPDATAs
                     where L.EMPNO == Empno
                     select L;
            return LE.FirstOrDefault();
        }
        public static List<EMPDATA> EmpData()
        {
            var emp = from E1 in D.EMPDATAs
                      select E1;
            return emp.ToList();
        }
    }
}