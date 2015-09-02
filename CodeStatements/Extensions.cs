using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;

namespace TypescriptCodeDom.CodeStatements
{
    public static class Extensions
    {
        public static string GetStatementsFromCollection(this CodeStatementCollection statementCollection, IStatementFactory statementFactory, CodeGeneratorOptions options)
        {
            return statementCollection
                .OfType<CodeStatement>()
                .Select(statement =>
                {
                    var statementLines = statementFactory.GetStatement(statement, options);
                    return statementLines.Expand();
                })
                .Aggregate((previous, current) => $"{previous}{Environment.NewLine}{current}");
        }
    }
}
