using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.BaseReference
{
    class TypescriptBaseReferenceExpression : ITypescriptBaseReferenceExpression
    {
        private readonly CodeBaseReferenceExpression _codeExpression;
        private readonly CodeGeneratorOptions _options;

        public TypescriptBaseReferenceExpression(
            CodeBaseReferenceExpression codeExpression, 
            CodeGeneratorOptions options)
        {
            _codeExpression = codeExpression;
            _options = options;
            System.Diagnostics.Debug.WriteLine("TypescriptBaseReferenceExpression Created");
        }

        public string Evaluate()
        {
            return "this";
        }
    }
}