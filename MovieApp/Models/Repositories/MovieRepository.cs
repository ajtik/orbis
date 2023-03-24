using System;
using Microsoft.EntityFrameworkCore;
using Context = MovieApp.Context;

namespace MovieApp.Models.Repositories
{
	public class MovieRepository : IMovieRepository
    {
        private Context.AppContext _dbContext;

		public MovieRepository(Context.AppContext dbContext)
		{
            _dbContext = dbContext;
		}

        public List<Movie> FindAll()
        {
            return _dbContext.Movies.Include(m => m.Genre).ToList();
        }

        public bool AddMovie(string name, string photoPath, string description, Genre genre)
        {
            _dbContext.Movies.Add(new Movie() {
                Genre = genre,
                Name = name,
                Description = description,
                Photo = photoPath
            });

            if (_dbContext.SaveChanges() == 1)
            {
                return true;
            }

            return false;
        }

        public bool DeleteMovie(Movie movie)
        {
            _dbContext.Remove(movie);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
