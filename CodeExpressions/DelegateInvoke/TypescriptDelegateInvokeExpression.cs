using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;

namespace TypescriptCodeDom.CodeExpressions.DelegateInvoke
{
    class TypescriptDelegateInvokeExpression : ITypescriptDelegateInvokeExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptDelegateInvokeExpression(
            IExpressionFactory expressionFactory)
        {
            _expressionFactory = expressionFactory;
        }

        public string Evaluate(CodeDelegateInvokeExpression codeExpression, CodeGeneratorOptions options)
        {
            var parameters = codeExpression.Parameters.GetParametersFromExpressions(_expressionFactory, options);

            var targetObject = _expressionFactory.GetExpression(codeExpression.TargetObject);

            return $"{targetObject.Evaluate(codeExpression, options)}({string.Join(", ", parameters)})";
        }
    }
}