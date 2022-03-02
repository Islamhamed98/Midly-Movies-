using Midly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Midly.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}