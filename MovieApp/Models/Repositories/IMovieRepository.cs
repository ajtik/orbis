using System;

namespace MovieApp.Models.Repositories
{
	public interface IMovieRepository
	{
		List<Movie> FindAll();
		Movie? FindById();
		bool AddMovie(string name, string photoPath, string description, Genre genre);
		bool DeleteMovie(Movie movie);
    }
}

