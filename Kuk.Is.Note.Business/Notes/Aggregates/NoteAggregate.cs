namespace Kuk.Is.Note.Business.Notes.Records;

public class NoteAggregate {
  private readonly List<(DateTime, string)> _contentHistory;

  public NoteAggregate(NoteId noteId!!, string content!!)
    : this(noteId, content, DateTime.UtcNow, Array.Empty<(DateTime, string)>()){
  }

  public NoteAggregate(NoteId noteId!!, string content!!, DateTime changeDate, IEnumerable<(DateTime, string)> contentHistory!!) {
    this.NoteId = noteId;

    VerifyContent(content);
    this.Content = content;
    this.ChangeDate = changeDate;
    _contentHistory = contentHistory.ToList();
  }

  public NoteId NoteId { get; }
  public string Content { get; private set; }
  public DateTime ChangeDate { get; private set; }
  // Content history isn't used in the app.
  public IReadOnlyCollection<(DateTime, string)> ContentHistory => _contentHistory;

  public void ChangeContent(string newContent!!) {
    VerifyContent(newContent);
    _contentHistory.Add((this.ChangeDate, this.Content));
    this.Content = newContent;
    this.ChangeDate = DateTime.UtcNow;
  }

  // Verify content satisfies our business rules - no specific rule were provided and I decided to disallow whitespace notes.
  private static void VerifyContent(string content!!) {
    if (string.IsNullOrWhiteSpace(content)) {
      throw new Exception("Content for notes may not be null, empty, or white space.");
    }
  }
}