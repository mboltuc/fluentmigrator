using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMigrator.Runner.Extensions
{
  public static class StringExtensions
  {
    public static string ReplaceFirst(this string s, string findValue, string newValue)
    {
      int findIndex = s.IndexOf(findValue);
      if (findIndex != -1)
        return s.Substring(0, findIndex) + newValue + s.Substring(findIndex + findValue.Length);
      return s;
    }
  }
}
