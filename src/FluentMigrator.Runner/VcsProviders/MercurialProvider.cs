using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace FluentMigrator.Runner.VcsProviders
{
  public class MercurialProvider : VcsProviderBase
  {
    private const string CatCommandFormat = @"cat ""{0}"" -r {1}";

    private IExternalCommand ExternalCommand { get; set; }

    public MercurialProvider(IExternalCommand externalCommand, string vcsDirectory, IAnnouncer announcer)
      : base(vcsDirectory, announcer)
    {
      if (externalCommand == null)
        throw new ArgumentNullException();

      ExternalCommand = externalCommand;
    }

    public MercurialProvider(string vcsDirectory, IAnnouncer announcer)
      : this(new ExternalCommand(announcer), vcsDirectory, announcer) 
    {}

    public override string GetFileContents(string filePathFromBase, string revision)
    {
      var hgCommand = BuildHgCommand(filePathFromBase, revision);
      return ExternalCommand.Execute("hg", hgCommand);
    }

    string BuildHgCommand(string filePathFromBase, string revision)
    {
      var absoluteFilePath = Path.Combine(ResolveToRootedPathIfNeeded(VcsDirectory), filePathFromBase);
      return String.Format(CatCommandFormat, absoluteFilePath, revision);
    }
  }
}
