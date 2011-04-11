using FluentMigrator.Expressions;
using FluentMigrator.Infrastructure;
using FluentMigrator.Tests.Helpers;
using NUnit.Framework;
using NUnit.Should;

namespace FluentMigrator.Tests.Unit.Expressions
{
  public class DbObjectExpressionBaseTests
  {
    [Test]
    public void ErrorIsReturnedWhenRepositoryIsNull()
    {
      var expression = new CreateDbObjectExpression() { Repository = null };
      var errors = ValidationHelper.CollectErrors(expression);
      errors.ShouldContain(ErrorMessages.RepositoryCannotBeNull);
    }

    [Test]
    public void ErrorIsReturnedWhenScriptPathIsNullOrEmpty()
    {
      var expression = new CreateDbObjectExpression() { ScriptPath = null };
      var errors = ValidationHelper.CollectErrors(expression);
      errors.ShouldContain(ErrorMessages.ScriptPathCannotBeNullOrEmpty);
    }

    [Test]
    public void ErrorIsReturnedWhenScriptRevisionIsNullOrEmpty()
    {
      var expression = new CreateDbObjectExpression() { ScriptRevision = null };
      var errors = ValidationHelper.CollectErrors(expression);
      errors.ShouldContain(ErrorMessages.ScriptRevisionCannotBeNullOrEmpty);
    }
  }
}
