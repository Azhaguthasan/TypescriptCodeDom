using System.CodeDom;
using System.Linq;
using TypescriptCodeDom.CodeExpressions;
using TypescriptCodeDom.Common;
using TypescriptCodeDom.Common.TypeMapper;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeTypeMembers
{
    class TypescriptMemberField : IMember
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly ITypescriptTypeMapper _typescriptTypeMapper;
        private readonly CodeMemberField _member;
        private readonly CodeGeneratorOptions _options;
        public TypescriptMemberField(
            IExpressionFactory expressionFactory,
            ITypescriptTypeMapper typescriptTypeMapper,
            CodeMemberField member,
            CodeGeneratorOptions options)
        {
            _expressionFactory = expressionFactory;
            _typescriptTypeMapper = typescriptTypeMapper;
            _member = member;
            _options = options;
        }


        public string Expand()
        {
            var isEnum = !(bool)_member.UserData["GenerateFieldType"];
            var shouldGenerateAccessModifier = (bool)_member.UserData["GenerateAccessModifier"];
            if (isEnum)
            {
                if (_member.InitExpression == null)
                {
                    return $"{_options.IndentString}{_member.Name},";
                }
                else
                {
                    var initializationExpression = _expressionFactory.GetExpression(_member.InitExpression, new System.CodeDom.Compiler.CodeGeneratorOptions()).Evaluate();
                    return _options.IndentString + (initializationExpression == null ? $"{_member.Name}," : $"{_member.Name}={initializationExpression},");
                }
            }

            string fieldDeclaration = $"{_member.Name.ConvertPascalCaseToCamelCase()}: {_typescriptTypeMapper.GetTypeOutput(_member.Type)};";
            var accessModifier = shouldGenerateAccessModifier ? _member.GetAccessModifier() : string.Empty;
            return $"{_options.IndentString}{accessModifier}{fieldDeclaration}";
        }
    }
}