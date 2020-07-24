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
        public IActionResult Index()
        {
            return View();
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
