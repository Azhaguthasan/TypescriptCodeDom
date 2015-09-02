using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.ArgumentReference
{
    public class TypescriptArgumentReferenceExpression : ITypescriptArgumentReferenceExpression
    {
        public string Evaluate(CodeArgumentReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            return codeExpression.ParameterName;
        }
    }
}
