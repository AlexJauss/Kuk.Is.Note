using Kuk.Is.Note.Business.Notes.Records;

namespace Kuk.Is.Note.Business.Notes.Repositories;

public interface INoteRepository {
  public NoteAggregate GetNoteAggregateById(NoteId id);
  public ICollection<NoteId> GetNoteIds();
  public void SaveNoteAggregate(NoteAggregate aggregate);
  public void DeleteNoteById(NoteId id);
}