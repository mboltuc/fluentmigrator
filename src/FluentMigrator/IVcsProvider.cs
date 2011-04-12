namespace FluentMigrator
{
  public interface IVcsProvider
  {
    string VcsDirectory { get; set; }
    string GetFileContents(string filePathFromBase, string revision);
  }
}