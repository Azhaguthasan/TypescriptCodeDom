using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;

namespace TypescriptCodeDom.CodeExpressions.Indexer
{
    class TypescriptIndexerExpression : ITypescriptIndexerExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptIndexerExpression(
            IExpressionFactory expressionFactory)
        {
            _expressionFactory = expressionFactory;
        }


        public string Evaluate(CodeIndexerExpression codeExpression, CodeGeneratorOptions options)
        {
            var targetObjectExpression = _expressionFactory.GetExpression(codeExpression.TargetObject);

            var indexers = codeExpression.Indices
                .OfType<CodeExpression>()
                .Select(expression =>
                {
                    var indexExpression = _expressionFactory.GetExpression(expression);
                    return indexExpression.Evaluate(codeExpression, options);
                })
                .Aggregate((previous, current) => $"{previous}[{current}]");

            return $"{targetObjectExpression.Evaluate(codeExpression, options)}.{indexers}";

        }
    }
}