using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator.Expressions;

namespace FluentMigrator.Builders.Create.DbObject
{
  public class CreateDbObjectExpressionBuilder : ExpressionBuilderBase<CreateDbObjectExpression>,
    ICreateDbObjectFromSourceControlSyntax,
    IMercurialSyntax
  {
    public CreateDbObjectExpressionBuilder(CreateDbObjectExpression expression)
      : base(expression)
    {
    }

    public IMercurialSyntax FromHg(string pathToRepository)
    {
      Expression.Repository = new MercurialRepository(pathToRepository);
      return this;
    }

    public void Script(string pathToScriptFromRepoBase, string revision)
    {
      Expression.ScriptPath = pathToScriptFromRepoBase;
      Expression.ScriptRevision = revision;
    }
  }
}
