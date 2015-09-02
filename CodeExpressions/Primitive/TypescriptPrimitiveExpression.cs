using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.Primitive
{
    class TypescriptPrimitiveExpression : ITypescriptPrimitiveExpression
    {
        public string Evaluate(CodePrimitiveExpression codeExpression, CodeGeneratorOptions options)
        {
            var expressionValue = codeExpression.Value.ToString();
            return codeExpression.Value is string ? $"\"{codeExpression.Value}\"" : expressionValue;
        }
    }
}