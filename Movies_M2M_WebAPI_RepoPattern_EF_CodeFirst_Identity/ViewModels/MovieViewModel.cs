using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EF_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF_Identity.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<SelectListItem> Actors { get; set; }
    }
}
