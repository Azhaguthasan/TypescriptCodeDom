using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.Direction
{
    class TypescriptDirectionExpression : ITypescriptDirectionExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptDirectionExpression(
            IExpressionFactory expressionFactory)
        {
            _expressionFactory = expressionFactory;
        }

        public string Evaluate(CodeDirectionExpression codeExpression, CodeGeneratorOptions options)
        {
            var parameterExpression = _expressionFactory.GetExpression(codeExpression);
            return parameterExpression.Evaluate(codeExpression, options);
        }
    }
}