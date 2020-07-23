using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalRazor.Model
{
    public class Film
    {
        [Key]
        public int Id { get;  set; }

        [Required]
        public string Title { get; set; }

        public string Director { get; set; }

        public string Year { get; set; }

    }
}
