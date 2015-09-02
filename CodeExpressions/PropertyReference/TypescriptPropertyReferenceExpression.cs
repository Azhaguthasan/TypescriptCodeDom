using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.PropertyReference
{
    class TypescriptPropertyReferenceExpression : ITypescriptPropertyReferenceExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptPropertyReferenceExpression(
            IExpressionFactory expressionFactory)
        {
            _expressionFactory = expressionFactory;
        }


        public string Evaluate(CodePropertyReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            var targetObject = _expressionFactory.GetExpression(codeExpression.TargetObject);
            return $"{targetObject.Evaluate(codeExpression, options)}.{codeExpression.PropertyName}";
        }
    }
}