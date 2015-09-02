using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.EventReference
{
    class TypescriptEventReferenceExpression : ITypescriptEventReferenceExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptEventReferenceExpression(
            IExpressionFactory expressionFactory
            )
        {
            _expressionFactory = expressionFactory;
        }

        public string Evaluate(CodeEventReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            var targetObjectExpression = _expressionFactory.GetExpression(codeExpression);
            return $"{targetObjectExpression.Evaluate(codeExpression, options)}.{codeExpression.EventName}";
        }
    }
}