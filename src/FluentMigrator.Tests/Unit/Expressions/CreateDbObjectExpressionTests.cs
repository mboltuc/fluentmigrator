using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator.Builders.Create.DbObject;
using NUnit.Framework;
using NUnit.Should;
using FluentMigrator.Expressions;
using FluentMigrator.Tests.Helpers;
using FluentMigrator.Infrastructure;
using Moq;

namespace FluentMigrator.Tests.Unit.Expressions
{
  public class CreateDbObjectExpressionTests
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

    [Test]
    public void ToStringIsDescriptive()
    {
      const string scriptPath = "my/script/path";
      const string scriptRevision = "1";

      var fakeRepo = new Mock<ISourceControlRepository>();
      var expression = new CreateDbObjectExpression();
      expression.Repository = fakeRepo.Object;
      expression.ScriptPath = scriptPath;
      expression.ScriptRevision = scriptRevision;

      var expStr = expression.ToString();

      Assert.That(expStr, Contains.Substring("CreateDbObject"));
      Assert.That(expStr, Contains.Substring(fakeRepo.Object.ToString()));
      Assert.That(expStr, Contains.Substring(scriptPath));
      Assert.That(expStr, Contains.Substring(scriptRevision));
    }
  }
}
