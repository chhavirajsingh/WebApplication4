using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Model;

namespace WebApplication4.Controllers
{
    public class Employee2Controller : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            var dept = dbContext.Departments.ToList();
            return View(dept);
        }

        public ActionResult EmployeeList(int id)
        {
            var emp = dbContext.Employees.Where(e => e.Department.Id == id).ToList();
            return View(emp);
        } 
        
        public ActionResult EmployeeDetails(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            return View(emp);
        }
    }
}