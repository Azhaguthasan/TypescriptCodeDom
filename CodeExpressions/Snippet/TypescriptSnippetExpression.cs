using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.Snippet
{
    class TypescriptSnippetExpression : ITypescriptSnippetExpression
    {
        public string Evaluate(CodeSnippetExpression codeExpression, CodeGeneratorOptions options)
        {
            return codeExpression.Value;
        }
    }
}