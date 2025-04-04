using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;
using System.Linq;

namespace MunicipalityManagementSystem.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reports
        public IActionResult Index()
        {
            var reports = _context.Reports.Include(r => r.Citizen).ToList();
            return View(reports);
        }

        // GET: Reports/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = _context.Reports
                .Include(r => r.Citizen)
                .FirstOrDefaultAsync(m => m.ReportID == id).Result;
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }


        // GET: Reports/Create
        public IActionResult Create()
        {
            // Get the list of citizens from the database
            var citizenList = _context.Citizens.ToList();

            // Create a SelectList for the CitizenID dropdown
            ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName");

            return View();
        }

        // POST: Reports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CitizenID,ReportType,Details,SubmissionDate,Status")] Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
               foreach (var modelStateKey in ModelState.Keys)
{
    var modelStateVal = ModelState[modelStateKey];
    if (modelStateVal != null) // Check if modelStateVal is not null
    {
        foreach (var error in modelStateVal.Errors)
        {
            var keyName = modelStateKey;
            var errorMessage = error.ErrorMessage;
            // Log or handle the error message
            Console.WriteLine($"Key: {keyName}, Error: {errorMessage}");
        }
    }
}
                // If the model is not valid, repopulate the CitizenID dropdown
                var citizenList = _context.Citizens.ToList();
                ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", report.CitizenID);
                return View(report);
            }
        }

        // GET: Reports/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = _context.Reports.FindAsync(id).Result;
            if (report == null)
            {
                return NotFound();
            }
            // If the model is not valid, repopulate the CitizenID dropdown
            var citizenList = _context.Citizens.ToList();
            ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", report.CitizenID);
            return View(report);
        }

        // POST: Reports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ReportID,CitizenID,ReportType,Details,SubmissionDate,Status")] Report report)
        {
            if (id != report.ReportID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.ReportID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            // If the model is not valid, repopulate the CitizenID dropdown
            var citizenList = _context.Citizens.ToList();
            ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", report.CitizenID);
            return View(report);
        }

        // GET: Reports/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = _context.Reports
                .Include(r => r.Citizen)
                .FirstOrDefaultAsync(m => m.ReportID == id).Result;
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var report = _context.Reports.FindAsync(id).Result;
            if (report != null)
            {
                _context.Reports.Remove(report);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(int id)
        {
            return _context.Reports.Any(e => e.ReportID == id);
        }
    }
}