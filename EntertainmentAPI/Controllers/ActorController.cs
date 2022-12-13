using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntertainmentAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntertainmentAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ActorController : ControllerBase
  {
    private readonly ILogger<ActorController> _logger;
    private Entities _entities;
    public ActorController(ILogger<ActorController> logger, Entities entities)
    {
      _logger = logger;
      _entities = entities;
    }

    [HttpGet]
    public IEnumerable<Actor> Get(int id = 0)
    {
      return _entities.Actors.ToArray();
    }
  }
}
