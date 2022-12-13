using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntertainmentAPI.Model
{
  public class Movie
  {
    [Key]
    public int MovieId { get; set; }
    public string Name { get; set; }
    [ForeignKey("ProducerId")]
    public int ProducerId { get; set; }
    public DateTime DOR { get; set; }

    public virtual Producer Producer { get; set; }

    public virtual ICollection<MovieActor> MovieActors { get; set; }
    public virtual ICollection<Actor> Actors { get; set; }
  }
}
