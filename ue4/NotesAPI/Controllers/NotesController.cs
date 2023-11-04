using Microsoft.AspNetCore.Mvc;

namespace NotesAPI.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class NotesController : ControllerBase {
    private const string AUTH_COOKIE_NAME = "token";

    private readonly NotesContext notesContext = NotesContextSingleton.Context;

    private async Task<bool> Verify() {
      if (Request.Cookies.TryGetValue(AUTH_COOKIE_NAME, out var token)) {
        using var client = new HttpClient();
        var response = await client.PostAsJsonAsync<object>(
          requestUri: "http://NotesLogin:3000/verify",
          value: new { token }
        );

        if (response.IsSuccessStatusCode) {
          return true;
        }
      }

      Response.StatusCode = 401;
      return false;
    }

    [HttpGet]
    public async Task<IEnumerable<Note>> Get() {
      return await Verify()
        ? notesContext.Notes.ToList()
        : Enumerable.Empty<Note>();
    }

    [HttpPost]
    public async Task PostNote([FromBody] Note note) {
      if (await Verify()) {
        notesContext.Notes.Add(note);
        notesContext.SaveChanges();
      }
    }
  }
}
