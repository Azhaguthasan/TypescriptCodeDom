using System.CodeDom;
using System.CodeDom.Compiler;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeExpressions.Cast
{
    class TypescriptCastExpression : ITypescriptCastExpression
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly ITypescriptTypeMapper _typescriptTypeMapper;

        public TypescriptCastExpression(
            IExpressionFactory expressionFactory,
            ITypescriptTypeMapper typescriptTypeMapper)
        {
            _expressionFactory = expressionFactory;
            _typescriptTypeMapper = typescriptTypeMapper;
        }


        public string Evaluate(CodeCastExpression codeExpression, CodeGeneratorOptions options)
        {
            var typeOutput = _typescriptTypeMapper.GetTypeOutput(codeExpression.TargetType);
            var expression = _expressionFactory.GetExpression(codeExpression);
            var expressionToCast = expression.Evaluate(codeExpression, options);
            return $"<{typeOutput}>({expressionToCast})";
        }
    }
}