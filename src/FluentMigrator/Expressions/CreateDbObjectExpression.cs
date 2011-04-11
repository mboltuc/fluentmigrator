using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator.Builders.Create.DbObject;
using FluentMigrator.Infrastructure;
using System.Text.RegularExpressions;

namespace FluentMigrator.Expressions
{
  public class CreateDbObjectExpression : MigrationExpressionBase
  {
    public ISourceControlRepository Repository { get; set; }
    public string ScriptPath { get; set; }
    public string ScriptRevision { get; set; }

    public override void ExecuteWith(IMigrationProcessor processor)
    {
      processor.Process(this);
    }

    public override void CollectValidationErrors(ICollection<string> errors)
    {
      if (Repository == null)
        errors.Add(ErrorMessages.RepositoryCannotBeNull);
      if (String.IsNullOrEmpty(ScriptPath))
        errors.Add(ErrorMessages.ScriptPathCannotBeNullOrEmpty);
      if (String.IsNullOrEmpty(ScriptRevision))
        errors.Add(ErrorMessages.ScriptRevisionCannotBeNullOrEmpty);
    }

    public override string ToString()
    {
      return base.ToString() +
        String.Format(" {0}: '{1}' Revision {2}", 
          Repository, 
          ScriptPath, 
          ScriptRevision);}
  }
}
