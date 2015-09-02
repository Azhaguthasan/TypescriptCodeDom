using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.BaseReference
{
    class TypescriptBaseReferenceExpression : ITypescriptBaseReferenceExpression
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly CodeBaseReferenceExpression _expression;
        private readonly CodeGeneratorOptions _options;

        public TypescriptBaseReferenceExpression(
            IExpressionFactory expressionFactory,
            CodeBaseReferenceExpression expression,
            CodeGeneratorOptions options)
        {
            _expressionFactory = expressionFactory;
            _expression = expression;
            _options = options;
        }

        public string Evaluate(CodeBaseReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            return "this";
        }
    }
}