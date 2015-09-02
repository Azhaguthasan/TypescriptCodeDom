using System.CodeDom;
using System.CodeDom.Compiler;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeExpressions.DefaultValue
{
    class TypescriptDefaultValueExpression : ITypescriptDefaultValueExpression
    {
        private readonly ITypescriptTypeMapper _typescriptTypeMapper;

        public TypescriptDefaultValueExpression(ITypescriptTypeMapper typescriptTypeMapper)
        {
            _typescriptTypeMapper = typescriptTypeMapper;
        }

        public string Evaluate(CodeDefaultValueExpression codeExpression, CodeGeneratorOptions options)
        {
            return $"new {_typescriptTypeMapper.GetTypeOutput(codeExpression.Type)}()";
        }
    }
}