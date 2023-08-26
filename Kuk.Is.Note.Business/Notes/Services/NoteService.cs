using Kuk.Is.Note.Business.Notes.Records;
using Kuk.Is.Note.Business.Notes.Repositories;

namespace Kuk.Is.Note.Business.Notes.Services;
internal class NoteService : INoteService {
  private readonly INoteIdProvider _noteIdProvider;
  private readonly INoteRepository _noteRepository;

  public NoteService(INoteIdProvider noteIdProvider, INoteRepository noteRepository) {
    _noteIdProvider = noteIdProvider;
    _noteRepository = noteRepository;
  }

  public void ChangeNote(ChangeNoteArgs changeNoteArgs!!) {
    var aggregate = _noteRepository.GetNoteAggregateById(changeNoteArgs.NoteId);
    aggregate.ChangeContent(changeNoteArgs.NewContent);
    _noteRepository.SaveNoteAggregate(aggregate);
  }

  public NoteId CreateNote(CreateNoteArgs createNoteArgs!!) {
    var noteId = _noteIdProvider.NewNoteId();
    var aggregate = new NoteAggregate(noteId, createNoteArgs.Content);
    _noteRepository.SaveNoteAggregate(aggregate);
    return noteId;
  }

  public void DeleteNote(NoteId noteId!!) {
    _noteRepository.DeleteNoteById(noteId);
  }

  public NoteAggregate GetNoteById(NoteId id!!) => _noteRepository.GetNoteAggregateById(id);

  public ICollection<NoteId> GetNoteIds() => _noteRepository.GetNoteIds();
}