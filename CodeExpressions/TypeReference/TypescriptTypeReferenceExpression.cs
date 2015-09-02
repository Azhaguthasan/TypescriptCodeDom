using System.CodeDom;
using System.CodeDom.Compiler;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeExpressions.TypeReference
{
    class TypescriptTypeReferenceExpression : ITypescriptTypeReferenceExpression
    {
        private readonly ITypescriptTypeMapper _typescriptTypeMapper;

        public TypescriptTypeReferenceExpression(ITypescriptTypeMapper typescriptTypeMapper)
        {
            _typescriptTypeMapper = typescriptTypeMapper;
        }

        public string Evaluate(CodeTypeReferenceExpression codeExpression, CodeGeneratorOptions options)
        {
            var type = _typescriptTypeMapper.GetTypeOutput(codeExpression.Type);
            return type;
        }
    }
} 