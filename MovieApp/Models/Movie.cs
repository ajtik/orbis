using System;
namespace MovieApp.Models
{
	// třída reprezentující film
	public class Movie
	{
		public int Id { get; set; }
		public Genre Genre { get; set; }
		public string Photo { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
