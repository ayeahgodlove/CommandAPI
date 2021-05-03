using System.Collections.Generic;
using System.Linq;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Repository {
    public class CommandAPIRepo : ICommandAPIRepo {
        private readonly CommandContext _context;

        public CommandAPIRepo (CommandContext context) {
            _context = context;
        }
        public void CreateCommand (Command cmd) {
            throw new System.NotImplementedException ();
        }
        public void DeleteCommand (Command cmd) {
            throw new System.NotImplementedException ();
        }

        public IEnumerable<Command> GetAllCommands () {
            return _context.CommandItemsSet.ToList ();
        }

        public Command GetCommandById (int id) {
            return _context.CommandItemsSet.FirstOrDefault (p => p.Id == id);
        }

        public bool SaveChanges () {
            throw new System.NotImplementedException ();
        }

        public void UpdateCommand (Command cmd) {
            throw new System.NotImplementedException ();
        }
    }
}