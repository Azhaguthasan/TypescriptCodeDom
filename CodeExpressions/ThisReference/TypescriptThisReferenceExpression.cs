using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.ThisReference
{
    class TypescriptThisReferenceExpression : ITypescriptThisReferenceExpression
    {
        public string Evaluate(CodeThisReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            return "this";
        }
    }
}