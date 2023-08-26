using Kuk.Is.Note.Business.Notes.Records;

namespace Kuk.Is.Note.Business.Notes.Services;

public interface INoteService {
  public void ChangeNote(ChangeNoteArgs changeNoteArgs);
  public NoteId CreateNote(CreateNoteArgs createNoteArgs);
  public void DeleteNote(NoteId noteId);
  public NoteAggregate GetNoteById(NoteId id);
  public ICollection<NoteId> GetNoteIds();
}