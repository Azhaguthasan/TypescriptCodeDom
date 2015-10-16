using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.PropertyReference
{
    class TypescriptPropertyReferenceExpression : ITypescriptPropertyReferenceExpression
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly CodePropertyReferenceExpression _codeExpression;
        private readonly CodeGeneratorOptions _options;

        public TypescriptPropertyReferenceExpression(
            IExpressionFactory expressionFactory, 
            CodePropertyReferenceExpression codeExpression, 
            CodeGeneratorOptions options)
        {
            _expressionFactory = expressionFactory;
            _codeExpression = codeExpression;
            _options = options;
            System.Diagnostics.Debug.WriteLine("TypescriptPropertyReferenceExpression Created");
        }


        public string Evaluate()
        {
            var targetObject = _expressionFactory.GetExpression(_codeExpression.TargetObject, _options);
            return $"{targetObject.Evaluate()}.{_codeExpression.PropertyName}";
        }
    }
}