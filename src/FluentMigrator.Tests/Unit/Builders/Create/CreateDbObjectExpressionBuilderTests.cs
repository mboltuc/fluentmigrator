using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentMigrator.Builders.Create.DbObject;
using FluentMigrator.Expressions;

namespace FluentMigrator.Tests.Unit.Builders.Create
{
  [TestFixture]
  public class CreateDbObjectExpressionBuilderTests
  {
    [Test]
    public void CallingFromHgSetsMercurialRepository()
    {
      const string myRepoPath = "my/repo/path";
      var expression = new CreateDbObjectExpression();
      var builder = new CreateDbObjectExpressionBuilder(expression);
      builder.FromHg(myRepoPath);

      Assert.That(expression.Repository, Is.TypeOf<MercurialRepository>(), "Repository should be a Mercurial Repository");
      Assert.That(expression.Repository.RepositoryPath, Is.EqualTo(myRepoPath), "Repository path should equal '{0}'", myRepoPath);
    }

    [Test]
    public void CallScriptSetsScriptPathAndRevision()
    {
      const string scriptPath = "my/script/path";
      const string scriptRevision = "1";

      var expression = new CreateDbObjectExpression();
      var builder = new CreateDbObjectExpressionBuilder(expression);
      builder.Script(scriptPath, scriptRevision);

      Assert.That(expression.ScriptPath, Is.EqualTo(scriptPath), "ScriptPath should equal '{0}'", scriptPath);
      Assert.That(expression.ScriptRevision, Is.EqualTo(scriptRevision), "ScriptRevision should equal '{0}'", scriptRevision);
    }

  }
}
