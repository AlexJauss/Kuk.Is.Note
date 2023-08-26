using Infrastructure.Common.Modules;
using Kuk.Is.Note.Business.Notes.Services;

namespace Kuk.Is.Note.Business;
public class BusinessModule : ServiceModuleBase {
  public BusinessModule() {
    this.AddTransient<INoteService, NoteService>();
  }
}
