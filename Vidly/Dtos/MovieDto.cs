﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required()]
        [Range(1, 99)]
        public int Stock { get; set; }

    }
}