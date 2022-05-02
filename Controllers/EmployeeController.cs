using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Model;
namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = dbContext.Employees.ToList();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(string Name, string Email, string Gender, decimal Salary, string Mobile)
        //{
        //    var emp = new Employee()
        //    {
        //        Name=Name,
        //        Email=Email,
        //        Mobile=Mobile,
        //        Gender=Gender,
        //        Salary=Salary
        //    };
        //    dbContext.Employees.Add(emp);
        //    dbContext.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Create(string test)
        {

            string name=Request.Form[0];
            string email=Request.Form["Email"];
            string mobile=Request.Form["Mobile"];
            string gender=Request.Form["Gender"];
            string salary=Request.Form["Salary"];

            var emp = new Employee()
            {
                Name = name,
                Email = email,
                Mobile = mobile,
                Gender = gender,
                Salary = Convert.ToDecimal(salary)
            };
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            if (emp != null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index?error=invalid employee id");
            }
        }

        public ActionResult Edit(int? id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            dbContext.Entry(emp).State=System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}