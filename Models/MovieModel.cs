using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab22MoviePractice.Models
{
    public class MovieModel
    {
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        //[MaxLength(20)]
        public Genre Genre { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Actors { get; set; }

        [Required]
        public string Directors { get; set; }
    }
}
