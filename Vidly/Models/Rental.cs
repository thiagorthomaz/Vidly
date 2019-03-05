﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer customer { get; set; }

        [Required]
        public Movie movie { get; set; }

        [Required]
        public DateTime DateRentend { get; set; }

        public DateTime? DateRenturned { get; set; }




    }
}