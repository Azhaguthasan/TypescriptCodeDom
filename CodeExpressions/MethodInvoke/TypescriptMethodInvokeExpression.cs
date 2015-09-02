using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;

namespace TypescriptCodeDom.CodeExpressions.MethodInvoke
{
    class TypescriptMethodInvokeExpression : ITypescriptMethodInvokeExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptMethodInvokeExpression(
            IExpressionFactory expressionFactory)
        {
            _expressionFactory = expressionFactory;
        }

        public string Evaluate(CodeMethodInvokeExpression codeExpression, CodeGeneratorOptions options)
        {
            var methodExpression = _expressionFactory.GetExpression(codeExpression.Method);

            var parameters = codeExpression.Parameters.GetParametersFromExpressions(_expressionFactory, options);
            
            return $"{methodExpression.Evaluate(codeExpression.Method, options)}({string.Join(", ", parameters)})";
        }
    }
}