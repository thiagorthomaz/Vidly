using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }

        public string Title {
            get {
                if (Movie.Id == 0)
                {
                    return "New movie";
                }
                else {
                    return "Edit movie";
                }
            }
        }
    }
}