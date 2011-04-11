using System;
using System.IO;
using System.Reflection;

namespace FluentMigrator.Builders.Create.DbObject
{
  public class MercurialRepository : ISourceControlRepository
  {
    private IExternalCommand ExternalCommand { get; set; }

    public string RepositoryPath { get; set; }

    public MercurialRepository(IExternalCommand externalCommand, string repositoryPath)
    {
      if (externalCommand == null)
        throw new ArgumentNullException();

      if (String.IsNullOrEmpty(repositoryPath))
        throw new ArgumentNullException();

      ExternalCommand = externalCommand;
      RepositoryPath = repositoryPath;
    }

    public MercurialRepository(string repositoryPath) 
      : this(new ExternalCommand(), repositoryPath)
    {
    }

    public string GetFileContents(string filePathFromBaseOfRepo, string revision)
    {
      return ExternalCommand.Execute("hg", BuildCommand(filePathFromBaseOfRepo, revision));
    }

    public string BuildCommand(string filePathFromBaseOfRepo, string revision)
    {
      var repoPath = ResolveToRootedPathIfNeeded(RepositoryPath);
      var filePath = Path.Combine(repoPath, filePathFromBaseOfRepo);

      return String.Format(@"cat ""{0}"" -r {1}", filePath, revision);
    }

    public override string ToString()
    {
      return "hg";
    }

    private string ResolveToRootedPathIfNeeded(string path)
    {
      if (!Path.IsPathRooted(path))
        return Path.GetFullPath(Path.Combine(Assembly.GetExecutingAssembly().Location, RepositoryPath));
      return path;
    }
  }
}
