using Kuk.Is.Note.Business.Notes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kuk.Is.Note.App.Controllers;
[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase {
  private readonly ILogger<NoteController> _logger;
  private readonly INoteService _noteService;

  public NoteController(
    ILogger<NoteController> logger,
    INoteService noteService
    ) {
    _logger = logger;
    _noteService = noteService;
  }

  [HttpGet]
  public Guid[] Get() {
    var noteIds = _noteService.GetNoteIds();
    return noteIds.Select(noteId => noteId.Id).ToArray();
  }

  [HttpGet]
  [Route("{id}")]
  public NoteSummaryDto Get([FromRoute] Guid id) {
    var noteSummary = _noteService.GetNoteById(new(id));
    return new(noteSummary.NoteId.Id, noteSummary.Content);
  }

  [HttpPost]
  public Guid Create([FromBody] NoteArgs args) {
    var noteId = _noteService.CreateNote(new(args.Content));
    return noteId.Id;
  }

  [HttpPut]
  [Route("{id}")]
  public void Change([FromRoute] Guid id, [FromBody] NoteArgs args) {
    _noteService.ChangeNote(new(new(id), args.Content));
  }

  [HttpDelete]
  [Route("{id}")]
  public void Delete([FromRoute] Guid id) {
    _noteService.DeleteNote(new(id));
  }
}

public record NoteSummaryDto(Guid Id, string Content);
public record NoteArgs(string Content);