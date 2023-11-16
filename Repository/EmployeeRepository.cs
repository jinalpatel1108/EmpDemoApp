using EmpDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpDemoApp.Repository
{
    public class EmployeeRepository
    {
        public static IEnumerable<EmployeeMasterRtr_Result> GetAllEmployees()
        {
            EmployeeEntities db = new EmployeeEntities();
            return db.EmployeeMasterRtr();
        }
        public static IEnumerable<EmployeeByIdRtr_Result> GetEmployeeById(int id)
        {
            EmployeeEntities db = new EmployeeEntities();
            return db.EmployeeByIdRtr(id);
        }
        public static string AddEmployee(EmployeeClass employee)
        {
            EmployeeEntities db = new EmployeeEntities();
            return db.EmployeeInsertUpdate(employee.Id, employee.FirstName, employee.MiddleName, employee.LastName, "insert").FirstOrDefault().ToString();

        }

        public static string UpdateEmployee(EmployeeClass employee)
        {
            EmployeeEntities db = new EmployeeEntities();
            return db.EmployeeInsertUpdate(employee.Id, employee.FirstName, employee.MiddleName, employee.LastName, "update").FirstOrDefault().ToString();
        }

        public static string DeleteEmployee(int id)
        {
            EmployeeEntities db = new EmployeeEntities();
            return db.EmployeeDelete(id).FirstOrDefault().ToString();
        }
    }
}