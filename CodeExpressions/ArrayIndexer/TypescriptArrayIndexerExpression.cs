using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;

namespace TypescriptCodeDom.CodeExpressions.ArrayIndexer
{
    class TypescriptArrayIndexerExpression : ITypescriptArrayIndexerExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptArrayIndexerExpression(
            IExpressionFactory expressionFactory)
        {
            _expressionFactory = expressionFactory;
        }

        public string Evaluate(CodeArrayIndexerExpression codeExpression, CodeGeneratorOptions options)
        {

            var indexExpressions = codeExpression.Indices
                .OfType<CodeExpression>()
                .Select(expression =>
                {
                    var indexExpression = _expressionFactory.GetExpression(codeExpression);
                    return indexExpression.Evaluate(codeExpression, options);
                })
                .Aggregate((previous, current) => $"{previous}[{current}]");

            var targetObjectExpression = _expressionFactory.GetExpression(codeExpression);
            var targetObject = targetObjectExpression.Evaluate(codeExpression, options);

            return $"{targetObject}{indexExpressions}";
        }
    }
}