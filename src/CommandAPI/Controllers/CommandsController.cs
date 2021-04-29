using System.Collections.Generic;
using CommandAPI.Models;
using CommandAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase {
        private readonly ICommandAPIRepo _repository;
        public CommandsController (ICommandAPIRepo repository) {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands () {
            var commandItems = _repository.GetAllCommands ();
            return Ok (commandItems);
        }

        [HttpGet ("{id}")]
        public ActionResult<Command> GetAllCommandById (int id) {
            var cmd = _repository.GetCommandById (id);
            if (cmd == null) {
                return NotFound ();
            }
            return Ok (cmd);
        }
    }
}