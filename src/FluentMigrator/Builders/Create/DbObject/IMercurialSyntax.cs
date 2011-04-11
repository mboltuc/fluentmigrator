namespace FluentMigrator.Builders.Create.DbObject
{
  public interface IMercurialSyntax
  {
    void Script(string scriptPath, string revision);
  }
}
