using System.CodeDom;
using System.CodeDom.Compiler;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeExpressions.DelegateCreate
{
    class TypescriptDelegateCreateExpression : ITypescriptDelegateCreateExpression
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly CodeDelegateCreateExpression _expression;
        private readonly CodeGeneratorOptions _options;
        private readonly TypescriptTypeMapper _typescriptTypeMapper;

        public TypescriptDelegateCreateExpression(
            IExpressionFactory expressionFactory,
            CodeDelegateCreateExpression expression,
            CodeGeneratorOptions options)
        {
            _expressionFactory = expressionFactory;
            _expression = expression;
            _options = options;
            _typescriptTypeMapper = new TypescriptTypeMapper();
        }

        public string Evaluate(CodeDelegateCreateExpression codeExpression, CodeGeneratorOptions options)
        {
            var expression = _expressionFactory.GetExpression(codeExpression);
            return $"{expression.Evaluate(codeExpression, options)}.{_expression.MethodName}";
        }
    }
}