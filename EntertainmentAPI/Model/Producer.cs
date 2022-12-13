using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntertainmentAPI.Model
{
  public class Producer
  {
    [Key]
    public int ProducerId { get; set; }
    public string Name { get; set; }
  }
}
