using System.CodeDom;
using System.CodeDom.Compiler;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeExpressions.TypeOf
{
    class TypescriptTypeOfExpression : ITypescriptTypeOfExpression
    {
        private ITypescriptTypeMapper _typescriptTypeMapper;

        public TypescriptTypeOfExpression(ITypescriptTypeMapper typescriptTypeMapper)
        {
            _typescriptTypeMapper = typescriptTypeMapper;
        }


        public string Evaluate(CodeTypeOfExpression codeExpression, CodeGeneratorOptions options)
        {
            var type = _typescriptTypeMapper.GetTypeOutput(codeExpression.Type);
            return $"instanceof {type}";
        }
    }
}