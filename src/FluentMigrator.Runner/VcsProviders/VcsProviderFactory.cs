using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMigrator.Runner.VcsProviders
{
  public static class VcsProviderFactory
  {
    public static IVcsProvider CreateProvider(string vcsProvider, string vcsDirectory, IAnnouncer announcer)
    {
      if (vcsProvider == "hg")
        return new MercurialProvider(vcsDirectory, announcer);
      return null;
    }

    public static string ListAvailableVCSProviders()
    {
      return "hg";
    }
  }
}
