using System;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Context
{
	
	// DBContext je třída z ORM EntityFrameworkCore, který nám umožňuje komunikaci s databází skrze objekty
	// nemusíme psát vlastní SQL příkazy a provádět serializace a další xxx věcí.. framework to udělá za nás
	// tato třída se následně používá v repozitářích
	public class AppContext : DbContext
	{
		// musíme nadefinovat property, která řekne se kterým typem objektu chceme pracovat(Movie, Genre)
		public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public AppContext(DbContextOptions<AppContext> options): base(options)
		{

		}
	}
}

