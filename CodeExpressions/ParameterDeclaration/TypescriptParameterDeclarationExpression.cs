using System.CodeDom;
using System.CodeDom.Compiler;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeExpressions.ParameterDeclaration
{
    class TypescriptParameterDeclarationExpression : ITypescriptParameterDeclarationExpression
    {
        private ITypescriptTypeMapper _typescriptTypeMapper;

        public TypescriptParameterDeclarationExpression(ITypescriptTypeMapper typescriptTypeMapper)
        {
            _typescriptTypeMapper = typescriptTypeMapper;
        }

        public string Evaluate(CodeParameterDeclarationExpression codeExpression, CodeGeneratorOptions options)
        {
            var type = _typescriptTypeMapper.GetTypeOutput(codeExpression.Type);
            return $"{codeExpression.Name}: {type}";
        }
    }
}  