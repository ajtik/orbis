using System;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Context
{
	public class AppContext : DbContext
	{
		public DbSet<Movie> Movies { get; set; }

		public AppContext(DbContextOptions<AppContext> options): base(options)
		{

		}
	}
}

