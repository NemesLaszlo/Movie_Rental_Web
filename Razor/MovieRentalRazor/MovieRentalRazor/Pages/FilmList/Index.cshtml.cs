using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieRentalRazor.Model;

namespace MovieRentalRazor.Pages.FilmList
{

    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Film> Films { get; set; }


        public async Task OnGet()
        {
            Films = await _db.Film.ToListAsync();
        }


        // post because of the delete button
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var film = await _db.Film.FindAsync(id);
            if(film == null)
            {
                return NotFound();
            }
            _db.Film.Remove(film);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}