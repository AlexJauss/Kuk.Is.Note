using Kuk.Is.Note.Business.Notes.Records;
using Kuk.Is.Note.Business.Notes.Repositories;

namespace Kuk.Is.Note.DummyRepository.Notes.Repositories;
internal class RandomNoteIdProvider : INoteIdProvider {
  public NoteId NewNoteId() => new(Guid.NewGuid());
}
