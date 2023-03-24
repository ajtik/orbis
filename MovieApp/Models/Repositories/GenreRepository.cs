using System;
using Microsoft.EntityFrameworkCore;
using Context = MovieApp.Context;

namespace MovieApp.Models.Repositories
{
	public class GenreRepository : IGenreRepository
    {
        private Context.AppContext _dbContext;

		public GenreRepository(Context.AppContext dbContext)
		{
            _dbContext = dbContext;
		}

        public List<Genre> FindAll()
        {
            return _dbContext.Genre.ToList();
        }

        public Genre? FindById(int id)
        {
            return _dbContext.Genre.Where(g => g.Id == id).FirstOrDefault();
        }
    }
}

