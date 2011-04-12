using System;
using System.Text;
using System.Diagnostics;

namespace FluentMigrator.Runner.VcsProviders
{
  public class ExternalCommand : IExternalCommand
  {
    IAnnouncer Announcer { get; set; }
    public ExternalCommand(IAnnouncer announcer)
    {
      Announcer = announcer;
    }

    public string Execute(string command, string arguments)
    {
      Announcer.Say(String.Format("{0} {1}", command, arguments));

      var process = new Process();
      process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.RedirectStandardError = true;
      process.StartInfo.FileName = command;
      process.StartInfo.Arguments = arguments;

      var errorOutput = new StringBuilder();

      process.ErrorDataReceived += (sender, e) =>
      {
        if (!String.IsNullOrEmpty(e.Data))
          errorOutput.AppendLine(e.Data);
      };

      process.Start();
      process.BeginErrorReadLine();
      var output = process.StandardOutput.ReadToEnd();
      process.WaitForExit();

      if (errorOutput.Length > 0)
        throw new InvalidOperationException(errorOutput.ToString());

      return output;
    }
  }
}
