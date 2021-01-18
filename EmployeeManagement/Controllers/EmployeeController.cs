using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        readonly List<Employee> emps;

        public EmployeeController()
        {
            emps = new List<Employee>();
            emps.Add(new Employee() { Id = 1, FirstName = "B", LastName = "b", Salary = 1000 });
            emps.Add(new Employee() { Id = 2, FirstName = "C", LastName = "c", Salary = 10000 });
            emps.Add(new Employee() { Id = 3, FirstName = "D", LastName = "d", Salary = 100000 });
            emps.Add(new Employee() { Id = 4, FirstName = "E", LastName = "e", Salary = 1000000 });
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(emps);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View(emps.FirstOrDefault(e => e.Id == id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employee = new Employee();
                    employee.FirstName = collection["FirstName"];
                    employee.LastName = collection["LastName"];
                    employee.Salary = Convert.ToInt32(collection["Salary"]);
                    emps.Add(employee);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(emps.FirstOrDefault(e => e.Id == id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employee = emps.FirstOrDefault(e => e.Id == id);
                    employee.FirstName = collection["FirstName"];
                    employee.LastName = collection["LastName"];
                    employee.Salary = Convert.ToInt32(collection["Salary"]);
                    
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(emps.FirstOrDefault(e => e.Id == id));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                emps.RemoveAll(e => e.Id == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
