﻿namespace FluentMigrator.Expressions
{
  public class CreateDbObjectExpression : DbObjectExpressionBase
  {
    public override void ExecuteWith(IMigrationProcessor processor)
    {
      processor.Process(this);
    }
  }
}
