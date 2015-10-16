using System.CodeDom;
using TypescriptCodeDom.CodeExpressions;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeTypeMembers
{
    class TypescriptMemberEvent : IMember
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly ITypescriptTypeMapper _typescriptTypeMapper;
        private readonly CodeMemberEvent _member;
        private readonly CodeGeneratorOptions _options;

        public TypescriptMemberEvent(
            IExpressionFactory expressionFactory,
            ITypescriptTypeMapper typescriptTypeMapper,
            CodeMemberEvent member,
            CodeGeneratorOptions options)
        {
            _expressionFactory = expressionFactory;
            _typescriptTypeMapper = typescriptTypeMapper;
            _member = member;
            _options = options;
        }

        public string Expand()
        {
            string eventDeclaration = $"{_member.Name}: Array<{_typescriptTypeMapper.GetTypeOutput(_member.Type)}>;";
            string accessModifier = _member.GetAccessModifier();
            return _options.IndentString+ $"{accessModifier}{eventDeclaration}";
        }
    }
}