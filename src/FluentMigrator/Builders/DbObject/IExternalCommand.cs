namespace FluentMigrator.Builders.Create.DbObject
{
  public interface IExternalCommand
  {
    string Execute(string command, string arguments);
  }
}