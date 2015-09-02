using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeExpressions.ObjectCreate
{
    class TypescriptObjectCreateExpression : ITypescriptObjectCreateExpression
    {
        private readonly IExpressionFactory _expressionFactory;
        private ITypescriptTypeMapper _typescriptTypeMapper;

        public TypescriptObjectCreateExpression(
            IExpressionFactory expressionFactory, ITypescriptTypeMapper typescriptTypeMapper)
        {
            _expressionFactory = expressionFactory;
            _typescriptTypeMapper = typescriptTypeMapper;
        }

        public string Evaluate(CodeObjectCreateExpression codeExpression, CodeGeneratorOptions options)
        {
            var type = _typescriptTypeMapper.GetTypeOutput(codeExpression.CreateType);
            var parameters = codeExpression.Parameters.GetParametersFromExpressions(_expressionFactory, options);

            return $"new {type}({string.Join(",", parameters)})";
        }
    }
}