using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // Required for SelectList
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MunicipalityManagementSystem.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var requests = _context.ServiceRequests.ToList();
            return View(requests);
        }

        public IActionResult Create()
        {
            // Get the list of citizens from the database
            var citizenList = _context.Citizens.ToList(); // Renamed variable

            // Create a SelectList for the CitizenID dropdown
            ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceRequest request)
        {
            // Get the list of citizens from the database
            var citizenList = _context.Citizens.ToList(); // Renamed variable

            if (ModelState.IsValid)
            {
                try
                {
                    _context.ServiceRequests.Add(request);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 547) // Error number for foreign key constraint violation
                    {
                        ModelState.AddModelError("CitizenID", "Invalid Citizen ID. Please select a valid citizen.");

                        // Repopulate the CitizenID dropdown
                        ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", request.CitizenID);

                        return View(request);
                    }
                    else
                    {
                        // Handle other database errors
                        ModelState.AddModelError("", "An error occurred while saving the service request. Please try again.");

                        // Repopulate the CitizenID dropdown
                        ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", request.CitizenID);

                        return View(request);
                    }
                }
            }

            // If the model is not valid, you need to repopulate the CitizenID dropdown
            ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", request.CitizenID);

            return View(request);
        }

        // GET: ServiceRequest/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = _context.ServiceRequests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            // Get the list of citizens from the database
            var citizenList = _context.Citizens.ToList(); // Renamed variable

            // Create a SelectList for the CitizenID dropdown
            ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", request.CitizenID);

            return View(request);
        }

        // POST: ServiceRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ServiceRequest request)
        {
            // Get the list of citizens from the database
            var citizenList = _context.Citizens.ToList(); // Renamed variable

            if (id != request.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.ServiceRequests.Update(request);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency exception (if needed)
                    return NotFound();
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 547) // Error number for foreign key constraint violation
                    {
                        ModelState.AddModelError("CitizenID", "Invalid Citizen ID. Please select a valid citizen.");

                        // Repopulate the CitizenID dropdown
                        ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", request.CitizenID);

                        return View(request);
                    }
                    else
                    {
                        // Handle other database errors
                        ModelState.AddModelError("", "An error occurred while saving the service request. Please try again.");

                        // Repopulate the CitizenID dropdown
                        ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", request.CitizenID);

                        return View(request);
                    }
                }
            }

            // If the model is not valid, you need to repopulate the CitizenID dropdown
            ViewBag.CitizenID = new SelectList(citizenList, "CitizenID", "FullName", request.CitizenID);

            return View(request);
        }

        // GET: ServiceRequest/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = _context.ServiceRequests.FirstOrDefault(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: ServiceRequest/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = _context.ServiceRequests
                .FirstOrDefault(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: ServiceRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var request = _context.ServiceRequests.Find(id);
            if (request != null) // Add null check
            {
                _context.ServiceRequests.Remove(request);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}