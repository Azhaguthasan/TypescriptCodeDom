using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeExpressions.ArrayCreate
{
    class TypescriptArrayCreateExpression : ITypescriptArrayCreateExpression
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly TypescriptTypeMapper _typescriptTypeMapper;

        public TypescriptArrayCreateExpression(IExpressionFactory expressionFactory, TypescriptTypeMapper typescriptTypeMapper)
        {
            _expressionFactory = expressionFactory;
            _typescriptTypeMapper = typescriptTypeMapper;
        }

        public string Evaluate(CodeArrayCreateExpression codeExpression, CodeGeneratorOptions options)
        {
            string sizeEvaluationString = string.Empty;
            if (codeExpression.SizeExpression != null)
            {
                var sizeExpression = _expressionFactory.GetExpression(codeExpression);
                sizeEvaluationString = sizeExpression.Evaluate(codeExpression, options);
            }
            else if (codeExpression.Size > 0)
            {
                sizeEvaluationString = codeExpression.Size.ToString();
            }

            var typeString = _typescriptTypeMapper.GetTypeOutput(codeExpression.CreateType);
            var arrayCreateString = $"{typeString}({sizeEvaluationString})";

            var initializers = codeExpression.Initializers
                .OfType<CodeExpression>()
                .Select(expression =>
                {
                    var initializerExpression = _expressionFactory.GetExpression(codeExpression);
                    return initializerExpression.Evaluate(codeExpression, options);
                })
                .ToList();

            if (initializers.Any())
                return $"{arrayCreateString}({string.Join(",", initializers)})";
            return $"{arrayCreateString}";
        }
    }
}