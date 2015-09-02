using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.FieldReference
{
    class TypescriptFieldReferenceExpression : ITypescriptFieldReferenceExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptFieldReferenceExpression(
            IExpressionFactory expressionFactory)
        {
            _expressionFactory = expressionFactory;
        }

        public string Evaluate(CodeFieldReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            var targetObjectExpression = _expressionFactory.GetExpression(codeExpression.TargetObject);
            return $"{targetObjectExpression.Evaluate(codeExpression, options)}.{codeExpression.FieldName}";
        }
    }
}