using Microsoft.AspNetCore.Mvc;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore; // Required for Include and other EF operations
using System.Threading.Tasks;

namespace MunicipalityManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var StaffList = _context.Staff.ToList();
            return View(StaffList);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken] // Recommended for security
        public IActionResult Create(Staff Staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staff.Add(Staff);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Staff);
        }

        // GET: Staff/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Staff = _context.Staff.Find(id);
            if (Staff == null)
            {
                return NotFound();
            }
            return View(Staff);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Staff Staff)
        {
            if (id != Staff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Staff.Update(Staff);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency exception (if needed)
                    return NotFound();
                }
            }
            return View(Staff);
        }

        // GET: Staff/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Staff = _context.Staff.FirstOrDefault(m => m.StaffID == id);
            if (Staff == null)
            {
                return NotFound();
            }

            return View(Staff);
        }

        // GET: Staff/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Staff = _context.Staff
                .FirstOrDefault(m => m.StaffID == id);
            if (Staff == null)
            {
                return NotFound();
            }

            return View(Staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Staff = _context.Staff.Find(id);
            _context.Staff.Remove(Staff);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}