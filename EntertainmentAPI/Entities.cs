using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EntertainmentAPI.Model;

namespace EntertainmentAPI
{
  public class Entities : DbContext
  {
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }

    public Entities(DbContextOptions<Entities> options) : base(options)
    {
      
    }
  }
}
