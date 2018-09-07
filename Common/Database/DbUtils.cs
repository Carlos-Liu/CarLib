using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarLib.Common.Database
{
  public static class DbUtils
  {
    // Refer to
    // https://stackoverflow.com/questions/439495/how-can-i-escape-square-brackets-in-a-like-clause
    // https://docs.microsoft.com/en-us/sql/t-sql/language-elements/like-transact-sql?view=sql-server-2017#pattern-matching-with-the-escape-clause
    /// <summary>
    /// Escapes the LIKE clause for SQL.
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns>The clause string which is escaped for SQL query.</returns>
    public static string EscapeForLikeSql(string param)
    {
      if (string.IsNullOrEmpty(param)) return "";

      return param.Replace("[", "[[]")
                  .Replace("%", "[%]")
                  .Replace("_", "[_]");
    }

    /// <summary>
    /// Escape T-SQL batch scripts.
    /// </summary>
    /// <param name="sqlScripts"></param>
    /// <returns></returns>
    public static IEnumerable<string> EscapeSqlGoStatements(string sqlScripts)
    {
      // there is USE [Database_Name] and GO in the scripts
      // but the GO is not T-SQL,
      // then we have to adapt this by
      // - remove the USE [xxx]
      // - split by GO
      // refer to: https://stackoverflow.com/questions/40814/execute-a-large-sql-script-with-go-commands

      // // make sure last batch is executed.
      sqlScripts += "\r\n GO";

      var result = new List<string>();

      var sqlStatementLines = sqlScripts.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
      var sqlBlock = new StringBuilder();
      foreach (var line in sqlStatementLines)
      {
        if (line.ToUpperInvariant().Trim() == "GO")
        {
          result.Add(sqlBlock.ToString());
          sqlBlock.Clear();
        }
        else
        {
          sqlBlock.AppendLine(line);
        }
      }

      return result.Where(elem => !string.IsNullOrWhiteSpace(elem));
    }
  }
}
