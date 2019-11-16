using MVC_EF_Identity.Models;
using MVC_EF_Identity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF_Identity.Data
{
    public interface IRepository
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int movieId);
        IEnumerable<Actor> GetActors();
        bool AddMovie(MovieViewModel movieViewModel);
        bool AddActor(Actor actor);
    }
}
