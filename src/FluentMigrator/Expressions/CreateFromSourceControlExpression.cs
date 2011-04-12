using System;
using System.Collections.Generic;
using FluentMigrator.Infrastructure;

namespace FluentMigrator.Expressions
{
  public class CreateFromSourceControlExpression : MigrationExpressionBase
  {
    public IVcsProvider VcsProvider { get; set; }
    public string ScriptPath { get; set; }
    public string ScriptRevision { get; set; }

    public override void ExecuteWith(IMigrationProcessor processor)
    {
      processor.Process(this);
    }

    public override void CollectValidationErrors(ICollection<string> errors)
    {
      if (VcsProvider == null)
        errors.Add(ErrorMessages.VcsProviderCannotBeNull);
      if (String.IsNullOrEmpty(ScriptPath))
        errors.Add(ErrorMessages.ScriptPathCannotBeNullOrEmpty);
      if (String.IsNullOrEmpty(ScriptRevision))
        errors.Add(ErrorMessages.ScriptRevisionCannotBeNullOrEmpty);
    }

    public string GetSqlText()
    {
      return VcsProvider.GetFileContents(ScriptPath, ScriptRevision);
    }
  }
}
