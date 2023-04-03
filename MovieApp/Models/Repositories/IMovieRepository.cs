using System;

namespace MovieApp.Models.Repositories
{
	
	// rozhraní pro MovieRepository, definuje pouze metody, které daná třída, která tohle rozhraní implementuje, musí
	// implementovat ... je to v podstatě taková hlavička co všechno je k dispozici ve třídě, která implementuje toto rozhraní
	public interface IMovieRepository
	{
		// metoda pro načtení všech filmů z databáze, vrací dynamické pole(List) s filmy
		// pole může být i prázdné pokud nenalezne žádné filmy
		// využito pro výpis filmů
		List<Movie> FindAll();
		// metoda pro získání jednoho filmu podle id - vrátí null nebo objekt typu Movie
		Movie? FindById(int id);
		// metoda pro update filmu 
		bool UpdateMovie(Movie movie);
		// metoda pro přidání filmu
		bool AddMovie(string name, string photoPath, string description, Genre genre);
		// metoda pro smazání filmu
		bool DeleteMovie(Movie movie);
    }
}

