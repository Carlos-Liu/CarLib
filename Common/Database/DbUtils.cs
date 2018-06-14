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
  }
}
