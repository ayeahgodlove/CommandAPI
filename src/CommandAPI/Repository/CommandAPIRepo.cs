using System;
using System.Collections.Generic;
using System.Linq;
using CommandAPI.Data;
using CommandAPI.DTOs;
using CommandAPI.Models;

namespace CommandAPI.Repository {
    public class CommandAPIRepo : ICommandAPIRepo {
        private readonly CommandContext _context;

        public CommandAPIRepo (CommandContext context) {
            _context = context;
        }
        public void CreateCommand (Command cmd) {
            if (cmd == null) {
                throw new ArgumentNullException (nameof (cmd));
            }
            _context.CommandItemsSet.Add (cmd);
        }

        public bool SaveChanges () {
            return (_context.SaveChanges () >= 0);
        }

        public IEnumerable<Command> GetAllCommands () {
            return _context.CommandItemsSet.ToList ();
        }

        public Command GetCommandById (int id) {
            return _context.CommandItemsSet.FirstOrDefault (p => p.Id == id);
        }

        public void UpdateCommand (Command cmd) {
            throw new System.NotImplementedException ();
        }
    }
}