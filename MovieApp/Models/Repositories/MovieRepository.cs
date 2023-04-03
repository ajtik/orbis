using System;
using Microsoft.EntityFrameworkCore;
using Context = MovieApp.Context;

namespace MovieApp.Models.Repositories
{
    // repozitář je třída, která zašťituje komunikaci s databázi(vyhledávání, zápis)
    // tato třída implementuje rozhrani IMovieRepository, tudíž musí být naimplemtnovány všechny její metody
    // to jestli jsou metody naimplementovány správně už je čistě na programátorovi, ten však musí dodržet vše z rozhraní(definici, návratové typy)
	public class MovieRepository : IMovieRepository
    {
        // privátní property pro práci s contextem
        private Context.AppContext _dbContext;

        // jelikož máme MovieRepository zaregistrované v DI kontejneru - udělali jsme v Program.cs
        // tak si tato služba může vyžádat další služby z DI kontejneru, v tomto případě Context.AppContext
		public MovieRepository(Context.AppContext dbContext)
		{
            _dbContext = dbContext;
		}

        public List<Movie> FindAll()
        {
            // vyhledání všech filmů, je třeba explicitně načíst relaci Genre, jinak bude null
            return _dbContext.Movies.Include(m => m.Genre).ToList();
        }

        public Movie? FindById(int id)
        {
            // vyhledání jedné entity z databáze pomocí podmínky WHERE
            return _dbContext.Movies.Where(m => m.Id == id).FirstOrDefault();
        }

        public bool AddMovie(string name, string photoPath, string description, Genre genre)
        {
            // "zaevidování" do DBContextu, aby věděla o našem nově vytvořeném objektu
            _dbContext.Movies.Add(new Movie() {
                Genre = genre,
                Name = name,
                Description = description,
                Photo = photoPath
            });

            // spustí samotné SQL pro uložení do databáze
            if (_dbContext.SaveChanges() == 1)
            {
                return true;
            }

            return false;
        }

        public bool DeleteMovie(Movie movie)
        {
            // "oznámení" kontextu o smazání filmu
            _dbContext.Remove(movie);
            // provede samotný SQL příkaz pro smazání
            _dbContext.SaveChanges();

            return true;
        }

        public bool UpdateMovie(Movie movie)
        {
            _dbContext.SaveChanges();

            return true;
        }
    }
}
