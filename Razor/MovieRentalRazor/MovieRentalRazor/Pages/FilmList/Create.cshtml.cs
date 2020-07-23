using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieRentalRazor.Pages.FilmList
{
    public class CreateModel : PageModel
    {
        private readonly Model.ApplicationDbContext _db;

        public CreateModel(Model.ApplicationDbContext db)
        {
            _db = db;
        }

        public Model.Film Film { get; set; }

        public void OnGet()
        {

        }
    }
}