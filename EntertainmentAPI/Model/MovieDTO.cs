using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntertainmentAPI.Model
{
  public class MovieDTO
  {
    public string Movie { get; set; }
    public string ProducerName { get; set; }
    public DateTime DOR { get; set; }
    public List<string> lstActors { get; set; }
  }

  public class AddMovieDTO
  {
    public string MovieName { get; set; }
    public int ProducerId { get; set; }
    public int MovieId { get; set; }
    public string ProducerName { get; set; }
    public DateTime DOR { get; set; }
    public List<Actor> lstActors { get; set; }
  }
}
