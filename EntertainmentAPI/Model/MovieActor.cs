using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntertainmentAPI.Model
{
  public class MovieActor
  {
    [Key]
    public int MovieActorId { get; set; }
    public int MovieId { get; set; }
    public int ActorId { get; set; }
    public virtual Actor Actor { get; set; }

  }

}
