using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly appDbContext _context;

        public EmployeesController(appDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
        //    Employee employee = new Employee()
        //    {
        //        Name = "ahmad",
        //        Email = "ahmad@gmail.com",
        //        Password = "ahmad123"
        //    };
        //    context.Employees.Add(employee);
        //    context.SaveChanges();
        var employees = _context.Employees.AsNoTracking().ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }

            return View(employees);
        }
        [HttpGet]
        public IActionResult create() 
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult create(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult delete(int id)
        {
            var emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult update(int id)
        {
            var emp=_context.Employees.Find(id);
            return View(emp);
        }
        public IActionResult edit(Employee emp)
        {
            var employee = _context.Employees.Find(emp.Id);
            employee.Name = emp.Name;
            employee.Email = emp.Email;
            if (emp.Password is not null)
            {
                employee.Password = emp.Password;
            }
           
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
