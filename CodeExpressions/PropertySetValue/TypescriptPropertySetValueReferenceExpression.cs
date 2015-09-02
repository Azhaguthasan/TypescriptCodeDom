using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.PropertySetValue
{
    class TypescriptPropertySetValueReferenceExpression : ITypescriptPropertySetValueReferenceExpression
    {
        public string Evaluate(CodePropertySetValueReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            return "value";
        }
    }
}