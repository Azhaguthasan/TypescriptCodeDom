using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.MethodReference
{
    class TypescriptMethodReferenceExpression : ITypescriptMethodReferenceExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptMethodReferenceExpression(
            IExpressionFactory expressionFactory)
        {
            _expressionFactory = expressionFactory;
        }

        public string Evaluate(CodeMethodReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            var targetObject = _expressionFactory.GetExpression(codeExpression.TargetObject);

            return $"{targetObject.Evaluate(codeExpression, options)}.{codeExpression.MethodName}";
        }
    }
}