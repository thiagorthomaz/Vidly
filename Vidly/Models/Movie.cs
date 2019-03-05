using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{

    public class Movie
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please inform movie's name")]
        [Display(Name = "Movie's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please inform a genre")]
        [Display(Name= "Genre")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Please inform the release date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        [Required(ErrorMessage = "Please inform the stock")]
        [Range(1,99)]
        public int Stock { get; set; }


        [Range(1, 99)]
        public int NumberAvailable { get; set; }

    }
}