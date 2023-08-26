using Kuk.Is.Note.Business.Notes.Records;
using Kuk.Is.Note.Business.Notes.Repositories;

namespace Kuk.Is.Note.DummyRepository.Notes.Repositories;

internal class StaticDictNoteRepository : INoteRepository {
  private static readonly object _lock = new();
  private static readonly Dictionary<NoteId, NoteAggregate> _noteAggregatesByNoteId = new();

  static StaticDictNoteRepository() {
    var dummy = new NoteAggregate(new(Guid.NewGuid()), "Dummy note");
    _noteAggregatesByNoteId.Add(dummy.NoteId, dummy);
  }

  public NoteAggregate GetNoteAggregateById(NoteId id!!) {
    lock (_lock) {
      return _noteAggregatesByNoteId.ContainsKey(id) ? _noteAggregatesByNoteId[id] : throw BuildIdNotFoundException(id);
    }
  }

  public ICollection<NoteId> GetNoteIds() {
    lock (_lock) {
      return _noteAggregatesByNoteId.Keys.ToArray();
    }
  }

  public void DeleteNoteById(NoteId id!!) {
    lock (_lock) {
      if (!_noteAggregatesByNoteId.Remove(id)) {
        throw BuildIdNotFoundException(id);
      }
    }
  }

  public void SaveNoteAggregate(NoteAggregate aggregate!!) {
    lock (_lock) {
      _noteAggregatesByNoteId[aggregate.NoteId] = aggregate;
    }
  }

  private static Exception BuildIdNotFoundException(NoteId id) => new($"Note not found! Unknown note-id was '{id}'.");
}
