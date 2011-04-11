using System;
using System.Text;
using System.Diagnostics;

namespace FluentMigrator.Builders.Create.DbObject
{
  public class ExternalCommand : IExternalCommand
  {
    public string Execute(string command, string arguments)
    {
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
