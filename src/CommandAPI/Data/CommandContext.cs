using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CommandAPI.Data {
    public class CommandContext : DbContext {
        public CommandContext (DbContextOptions<CommandContext> options) : base (options) {

        }
        public DbSet<Command> CommandItemsSet { get; set; } //table in the database
    }
}