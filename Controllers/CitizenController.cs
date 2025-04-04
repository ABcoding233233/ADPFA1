using Microsoft.AspNetCore.Mvc;
using MunicipalityManagementSystem.Models;
using MunicipalityManagementSystem.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore; // Required for Include and other EF operations
using System.Threading.Tasks;

namespace MunicipalityManagementSystem.Controllers
{
    public class CitizenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitizenController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var citizens = _context.Citizens.ToList();
            return View(citizens);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken] // Recommended for security
        public IActionResult Create(Citizen citizen)
        {
            if (ModelState.IsValid)
            {
                _context.Citizens.Add(citizen);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citizen);
        }

        // GET: Citizen/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = _context.Citizens.Find(id);
            if (citizen == null)
            {
                return NotFound();
            }
            return View(citizen);
        }

        // POST: Citizen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Citizen citizen)
        {
            if (id != citizen.CitizenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Citizens.Update(citizen);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency exception (if needed)
                    return NotFound();
                }
            }
            return View(citizen);
        }

        // GET: Citizen/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = _context.Citizens.FirstOrDefault(m => m.CitizenID == id);
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }

        // GET: Citizen/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = _context.Citizens
                .FirstOrDefault(m => m.CitizenID == id);
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }

        // POST: Citizen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var citizen = _context.Citizens.Find(id);
            _context.Citizens.Remove(citizen);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}