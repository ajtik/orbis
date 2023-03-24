using System;

namespace MovieApp.Models.Repositories
{
	public interface IGenreRepository
	{
		List<Genre> FindAll();
		Genre? FindById(int id);
	}
}
