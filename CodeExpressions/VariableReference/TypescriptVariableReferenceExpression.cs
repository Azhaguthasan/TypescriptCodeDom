using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.VariableReference
{
    class TypescriptVariableReferenceExpression : ITypescriptVariableReferenceExpression
    {
        public string Evaluate(CodeVariableReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            return codeExpression.VariableName;
        }
    }
}