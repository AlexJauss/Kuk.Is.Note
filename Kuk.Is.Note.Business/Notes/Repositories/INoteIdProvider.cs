using Kuk.Is.Note.Business.Notes.Records;

namespace Kuk.Is.Note.Business.Notes.Repositories;
public interface INoteIdProvider {
  public NoteId NewNoteId();
}