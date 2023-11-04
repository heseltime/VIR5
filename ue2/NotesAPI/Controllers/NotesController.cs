using Microsoft.AspNetCore.Mvc;

namespace NotesAPI.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class NotesController : ControllerBase {
    private readonly NotesContext notesContext = NotesContextSingleton.Context;

    [HttpGet]
    public IEnumerable<Note> Get() {
      return notesContext.Notes.ToList();
    }

    [HttpPost]
    public void PostNote([FromBody] Note note) {
      notesContext.Notes.Add(note);
      notesContext.SaveChanges();
    }
  }
}
