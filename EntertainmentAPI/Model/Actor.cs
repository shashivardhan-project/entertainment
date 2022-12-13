using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntertainmentAPI.Model
{
  public class Actor
  {
    [Key]
    public int ActorId { get; set; }
    public string Name { get; set; }
  }
}
