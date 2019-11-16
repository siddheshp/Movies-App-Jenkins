using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Identity.Models;
using MVC_EF_Identity.ViewModels;

namespace MVC_EF_Identity.Data
{
    public class MovieRepository : IRepository
    {
        ApplicationDbContext _dbContext = null;
        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddActor(Actor actor)
        {
            try
            {
                _dbContext.Actors.Add(actor);
                int result = _dbContext.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddMovie(MovieViewModel movieViewModel)
        {
            try
            {
                _dbContext.Movies.Add(movieViewModel.Movie);
                foreach (var actor in movieViewModel.Actors)
                {
                    if (actor.Selected)
                    {
                        _dbContext.MovieActors.Add(new MovieActor
                        {
                            Actor = _dbContext.Actors.Find(Convert.ToInt32(actor.Value)),
                            Movie = movieViewModel.Movie
                        });
                    }
                }

                int result = _dbContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Actor> GetActors()
        {
            return _dbContext.Actors.ToList();
        }

        public Movie GetMovieById(int movieId)
        {
            return _dbContext.Movies.Where(m => m.Id == movieId)
                .Include(m => m.MovieActors).FirstOrDefault();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.Include(m=>m.MovieActors);
        }
    }
}
