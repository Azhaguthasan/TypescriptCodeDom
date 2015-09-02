using System.CodeDom;
using TypescriptCodeDom.CodeExpressions;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeTypeMembers
{
    class TypescriptMemberField : IMember
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly ITypescriptTypeMapper _typescriptTypeMapper;
        private readonly CodeMemberField _member;

        public TypescriptMemberField(
            IExpressionFactory expressionFactory,
            ITypescriptTypeMapper typescriptTypeMapper,
            CodeMemberField member)
        {
            _expressionFactory = expressionFactory;
            _typescriptTypeMapper = typescriptTypeMapper;
            _member = member;
        }


        public string Expand()
        {
            string fieldDeclaration = $"{_member.Name}: {_typescriptTypeMapper.GetTypeOutput(_member.Type)};";
            var accessModifier = _member.GetAccessModifier();
            return $"{accessModifier}{fieldDeclaration}";
        }
    }
}