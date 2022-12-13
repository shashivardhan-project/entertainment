using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using EntertainmentAPI.Model;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MovieController : Controller
  {
    private readonly ILogger<MovieController> _logger;
    private Entities _entities;
    public MovieController(ILogger<MovieController> logger, Entities entities)
    {
      _logger = logger;
      _entities = entities;
    }

    [HttpGet]
    public IEnumerable<MovieDTO> Get()
    {
      IQueryable<MovieDTO> movies = null;
      var qry = _entities.Movies.Include(x => x.Producer).Include(y => y.MovieActors);

      movies = from m in qry
               select new MovieDTO() { Movie = m.Name, ProducerName = m.Producer.Name, lstActors = m.MovieActors.Select(x => x.Actor.Name).ToList() };
      return movies;
    }


    [HttpGet]
    [Route("GetAllMovies")]
    public IEnumerable<MovieDTO> GetAllMovies()
    {
      IQueryable<MovieDTO> movies = null;
      var qry = _entities.Movies.Include(x => x.Producer).Include(y => y.MovieActors);

      movies = from m in qry
               select new MovieDTO() { Movie = m.Name, ProducerName = m.Producer.Name, lstActors = m.MovieActors.Select(x => x.Actor.Name).ToList() };

      return movies;
    }

    [HttpPost]
    [Route("AddMovie")]
    public bool AddMovie(AddMovieDTO addMovieDTO)
    {
      return AddMovieDTO(addMovieDTO);
    }

    [HttpPost]
    [Route("UpdateMovie")]
    public bool UpdateMovie(AddMovieDTO addMovieDTO)
    {
      return UpdateMovieDTO(addMovieDTO);
    }

    // methods to add and update the movie 
    private bool AddMovieDTO(AddMovieDTO addMovieDTO)
    {
      bool isMovieAdded = false;
      if (addMovieDTO != null)
      {
        try
        {
          Movie movie = new Movie() { Name = addMovieDTO.MovieName, ProducerId = addMovieDTO.ProducerId,DOR=addMovieDTO.DOR, MovieActors = new List<MovieActor>(), Producer=new Producer() { ProducerId = addMovieDTO.ProducerId ,Name= addMovieDTO.ProducerName }};
          addMovieDTO.lstActors.ForEach(x => movie.MovieActors.Add(new MovieActor() { ActorId = x.ActorId }));
          _entities.Movies.Add(movie);
          int a = _entities.SaveChanges(true);
          isMovieAdded = a > 0 ? true : false;
        }
        catch (Exception ex)
        {

        }
      }
      return isMovieAdded;
    }
    private bool UpdateMovieDTO(AddMovieDTO addMovieDTO)
    {
      bool isMovieUpdated = false;
      if (addMovieDTO != null)
      {
        try
        {
          Movie movie = new Movie() { Name = addMovieDTO.MovieName, ProducerId = addMovieDTO.ProducerId, DOR = addMovieDTO.DOR, MovieActors = new List<MovieActor>() };
          addMovieDTO.lstActors.ForEach(x => movie.MovieActors.Add(new MovieActor() { ActorId = x.ActorId }));
          _entities.Movies.Update(movie);
          int a = _entities.SaveChanges(true);
          isMovieUpdated = a > 0 ? true : false;
        }
        catch (Exception ex)
        {

        }
      }
      return isMovieUpdated;
    }
  }
}
