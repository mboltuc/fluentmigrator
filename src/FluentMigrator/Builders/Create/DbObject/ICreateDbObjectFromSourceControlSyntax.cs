﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMigrator.Builders.Create.DbObject
{
  public interface ICreateDbObjectFromSourceControlSyntax
  {
    IMercurialSyntax FromHg(string pathToRepository);
  }
}
