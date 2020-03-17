using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoMvc.Models
{
    public class DBOperations
    {
        static DemoEntities D = new DemoEntities();
        
        public static string InsertEmp(EMPDATA E)
        {
            try
            {
                D.EMPDATAs.Add(E);
                D.SaveChanges();
            }

            catch (DbUpdateException Ey)
            {
                SqlException Ex = Ey.GetBaseException() as SqlException;
                if(Ex.Message.Contains("FK_EmpDept"))
                {
                    return "No Proper Deptno";
                }
                else if (Ex.Message.Contains("PK_EMP")) 
                {
                    return "Empno Cannot be empty";

                }
                else
                {
                    return "Error Occured";
                }
                
            }

            return "Done";
        }
        public static List<EMPDATA> GetDept(int Deptno)
        {
            var LE = from L in D.EMPDATAs
                     where L.DEPTNO == Deptno
                     select L;
            return LE.ToList();
        }
        public static List<EMPDATA> GetEmp(int Empno)
        {
            var LE = from L in D.EMPDATAs
                     where L.EMPNO == Empno
                     select L;
            return LE.ToList();
        }
        public static List<DEPTDATA> getDepts()
        {
            var dept = from D1 in D.DEPTDATAs
                       select D1;
            return dept.ToList();
        }

        public static List<EMPDATA> empdel1()
        {
            var emp = from E1 in D.EMPDATAs
                       select E1;
            return emp.ToList();
        }
        public static string empdelete(int Empno)
        {
            var emp = (from E in D.EMPDATAs
                       where E.EMPNO == Empno
                       select E).FirstOrDefault();
            D.EMPDATAs.Remove(emp);
            D.SaveChanges();
            return "1 Row Deleted";
        }
    }
   
}