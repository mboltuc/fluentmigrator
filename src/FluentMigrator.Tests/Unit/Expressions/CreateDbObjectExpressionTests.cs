﻿using FluentMigrator.Builders.Create.DbObject;
using FluentMigrator.Expressions;
using Moq;
using NUnit.Framework;

namespace FluentMigrator.Tests.Unit.Expressions
{
  public class CreateDbObjectExpressionTests
  {
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
