using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MovieRentalRazor.Pages.FilmList
{

    public class IndexModel : PageModel
    {
        private readonly Model.ApplicationDbContext _db;

        public IndexModel(Model.ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model.Film> Films { get; set; }

        public async Task OnGet()
        {
            Films = await _db.Film.ToListAsync();
        }
    }
}