using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        //Constructor
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employee/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                return View(_context.Employees.Find(id));
            }
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmployeeId, FullName, EmpCode, Position, OfficeLocation")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeId == 0)
                {
                    _context.Add(employee);
                }
                else
                {
                    _context.Update(employee);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        //GET: Employee/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

