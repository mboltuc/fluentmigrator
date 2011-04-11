namespace FluentMigrator.Builders.Create.DbObject
{
  public interface ISourceControlRepository
  {
    string RepositoryPath { get; set; }

    string GetFileContents(string filePathFromBaseOfRepo, string revision);
    string BuildCommand(string filePathFromBaseOfRepo, string revision);
  }
}
