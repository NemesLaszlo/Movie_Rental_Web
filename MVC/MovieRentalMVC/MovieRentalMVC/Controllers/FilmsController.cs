using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalMVC.Models;

namespace MovieRentalMVC.Controllers
{
    public class FilmsController : Controller
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Film Film { get; set; }

        public FilmsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // load all films to the table because of GetAll and the js script
        public IActionResult Index()
        {
            return View();
        }

        // navigate to the create or update page
        public IActionResult Upsert(int? id)
        {
            Film = new Film();
            if(id == null)
            {
                // Create
                return View(Film);
            }

            // Update
            Film = _db.Films.FirstOrDefault(u => u.Id == id);
            if (Film == null)
            {
                return NotFound();
            }

            return View(Film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Film.Id == 0)
                {
                    // Create
                    _db.Films.Add(Film);
                }
                else
                {
                    // Update
                    _db.Films.Update(Film);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Film);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Films.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var filmFromDb = await _db.Films.FirstOrDefaultAsync(u => u.Id == id);
            if (filmFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }

            _db.Films.Remove(filmFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
