using System;
using System.IO;
using System.Reflection;

namespace FluentMigrator.Runner.VcsProviders
{
  public abstract class VcsProviderBase : IVcsProvider
  {
    public string VcsDirectory { get; set; }
    IAnnouncer Announcer { get; set; }

    protected VcsProviderBase(string vcsDirectory, IAnnouncer announcer) 
    {
      if (String.IsNullOrEmpty(vcsDirectory))
        throw new ArgumentNullException();

      VcsDirectory = vcsDirectory;
      Announcer = announcer;
    }

    public abstract string GetFileContents(string filePathFromBase, string revision);

    protected virtual string ResolveToRootedPathIfNeeded(string path)
    {
      if (!Path.IsPathRooted(path))
        return Path.GetFullPath(Path.Combine(Assembly.GetExecutingAssembly().Location, path));
      return path;
    }
  }
}