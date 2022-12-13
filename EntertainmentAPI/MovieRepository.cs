using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using EntertainmentAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentAPI
{
  public class MovieRepository
  {
    public IEnumerable<Movie> GetAllMovies(Entities _entities)
    {
      IEnumerable<Movie> movies = null;
      DbContextOptions<Entities> options = new DbContextOptions<Entities>();
      using (var ents = new Entities(options))
      {
        movies = ents.Movies.Include(x => x.MovieActors);
      }

      return movies;
    }
  }
}
