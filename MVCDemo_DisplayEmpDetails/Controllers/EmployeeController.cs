using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo_DisplayEmpDetails.Models;

namespace MVCDemo_DisplayEmpDetails.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeID == id);
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee emp = new Employee();
            UpdateModel(emp);
            employeeContext.Employees.Add(emp);
            employeeContext.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeID == id);
            return View(employee);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Save()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee emp = new Employee();
            UpdateModel(emp);
            employeeContext.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            employeeContext.SaveChanges();

            return View(emp);
        }

        
    }
}