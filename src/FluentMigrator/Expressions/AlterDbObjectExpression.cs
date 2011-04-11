namespace FluentMigrator.Expressions
{
  public class AlterDbObjectExpression : DbObjectExpressionBase
  {
    public override void ExecuteWith(IMigrationProcessor processor)
    {
      processor.Process(this);
    }
  }
}
