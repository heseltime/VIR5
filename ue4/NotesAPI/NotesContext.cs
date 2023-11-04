using Microsoft.EntityFrameworkCore;

namespace NotesAPI {
  public class NotesContext : DbContext {
    public DbSet<Note> Notes => Set<Note>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Filename=/data/notes.db");
    }
  }
}
