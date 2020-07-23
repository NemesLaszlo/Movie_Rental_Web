using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieRentalRazor.Model;

namespace MovieRentalRazor.Pages.FilmList
{

    public class EditModel : PageModel
    {

        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Film Film { get; set; }

        public async Task OnGet(int id)
        {
            Film = await _db.Film.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var FilmFromDb = await _db.Film.FindAsync(Film.Id);
                FilmFromDb.Title = Film.Title;
                FilmFromDb.Director = Film.Director;
                FilmFromDb.Year = Film.Year;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}