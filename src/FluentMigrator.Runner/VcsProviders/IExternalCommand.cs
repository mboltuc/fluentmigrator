namespace FluentMigrator.Runner.VcsProviders
{
  public interface IExternalCommand
  {
    string Execute(string command, string arguments);
  }
}