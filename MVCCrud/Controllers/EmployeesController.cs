using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;

namespace MVCCrud.Controllers
{
    public class EmployeesController : Controller
    {

        public static IList<Employee> employees = new List<Employee>()
        {
            new Employee{Id = 1, Name="Ankit", Desgination="Trainee", Salary=12000},

            new Employee{Id = 2, Name="Ram", Desgination="Trainee", Salary=12000},
            
            new Employee{Id = 3, Name="Shyam", Desgination="Trainee", Salary=12000},
            
            new Employee{Id = 4, Name="Ramlal", Desgination="Trainee", Salary=12000}
        };

        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        //Partial View for Employee GRID
        public ActionResult EmployeeGrid()
        {
            return PartialView(employees);
        }

        public ActionResult EmployeeModal(int id)
        {
            if(id == 0)
            {
                Employee employee = new Employee()
                {
                    Id = employees.Count+1,
                    Name = "",
                    Desgination = "",
                    Salary = 0
                };
               
                return PartialView(employee);
            }
            else
            {
                var employee = employees.FirstOrDefault(e => e.Id == id);
                return PartialView(employee);
            }
            
        }

        [HttpPost]
        public bool UpdateEmployee(Employee employee)
        {
            var newemp = employees.FirstOrDefault(emp => emp.Id == employee.Id);
            if (newemp != null)
            {
                newemp.Id = employee.Id;
                newemp.Name = employee.Name;
                newemp.Desgination = employee.Desgination;
                newemp.Salary = employee.Salary;

                employees.Where(e => e.Id == employee.Id).ToList().ForEach(e =>
                {
                    e.Id = newemp.Id;
                    e.Name = newemp.Name;
                    e.Desgination = newemp.Desgination;
                    e.Salary = newemp.Salary;
                });
                return true;
            }
            else
            {
                employees.Add(employee);
                return true;
            }
        }

        public bool DeleteEmployee(int id)
        {
            if(employees.Contains(employees.Where(emp => emp.Id == id).First()))
            {
                employees.Remove(employees.Where(emp => emp.Id == id).First());
                return true;
            }
            else
            {
                return false;
            }
            
           
        }
    }
}