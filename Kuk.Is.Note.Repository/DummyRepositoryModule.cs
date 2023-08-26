using Infrastructure.Common.Modules;
using Kuk.Is.Note.Business.Notes.Repositories;
using Kuk.Is.Note.DummyRepository.Notes.Repositories;

namespace Kuk.Is.Note.DummyRepository;
public class DummyRepositoryModule : ServiceModuleBase {
  public DummyRepositoryModule() {
    this.AddTransient<INoteIdProvider, RandomNoteIdProvider>();
    this.AddTransient<INoteRepository, StaticDictNoteRepository>();
  }
}
