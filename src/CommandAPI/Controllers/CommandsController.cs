using System.Collections.Generic;
using AutoMapper;
using CommandAPI.DTOs;
using CommandAPI.Models;
using CommandAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase {
        private readonly ICommandAPIRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController (ICommandAPIRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands () {
            var commandItems = _repository.GetAllCommands ();
            return Ok (_mapper.Map<IEnumerable<CommandReadDTO>> (commandItems));
        }

        [HttpGet ("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetAllCommandById (int id) {
            var cmd = _repository.GetCommandById (id);
            if (cmd == null) {
                return NotFound ();
            }
            return Ok (_mapper.Map<CommandReadDTO> (cmd));
        }

        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand (CommandCreateDTO commandCreateDTO) {
            var commandModel = _mapper.Map<Command> (commandCreateDTO);
            _repository.CreateCommand (commandModel);
            _repository.SaveChanges ();
            var commandReadDTO = _mapper.Map<CommandReadDTO> (commandModel);
            return CreatedAtRoute ("GetCommandById",
                new { Id = commandReadDTO.Id },
                commandReadDTO);
        }

    }
}