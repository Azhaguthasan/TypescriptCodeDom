using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;
using TypescriptCodeDom.CodeTypeParameters;
using TypescriptCodeDom.Common.TypeMapper;

namespace TypescriptCodeDom.CodeTypeMembers
{
    public interface IMember
    {
        string Expand();
    }

    class TypescriptTypeDeclaration : IMember
    {
        private readonly CodeTypeDeclaration _typeDeclaration;
        private readonly IMemberFactory _memberFactory;
        private readonly ITypescriptTypeMapper _typescriptTypeMapper;
        private readonly ITypescriptTypeParameter _typescriptTypeParameter;
        private readonly CodeGeneratorOptions _options;

        public TypescriptTypeDeclaration(
            CodeTypeDeclaration typeDeclaration,
            IMemberFactory memberFactory,
            ITypescriptTypeMapper typescriptTypeMapper,
            ITypescriptTypeParameter typescriptTypeParameter,
            CodeGeneratorOptions options)
        {
            _typeDeclaration = typeDeclaration;
            _memberFactory = memberFactory;
            _typescriptTypeMapper = typescriptTypeMapper;
            _typescriptTypeParameter = typescriptTypeParameter;
            _options = options;
        }

        public string Expand()
        {
            var accessModifier = GetAccessModifier(_typeDeclaration.Attributes);
            var name = _typeDeclaration.Name;
            var typeType = GetTypeOfType(_typeDeclaration);
            var members = _typeDeclaration.Members
                .OfType<CodeTypeMember>()
                .Select(member => _memberFactory.GetMember(member, _options))
                .ToList();

            var membersExpression = string.Empty;
            if (members.Any())
            {
                membersExpression = string.Join(Environment.NewLine, members);
            }

            var typeParameters = _typeDeclaration.TypeParameters.OfType<CodeTypeParameter>()
                .Select(parameter => _typescriptTypeParameter.Evaluate(parameter))
                .ToList();
            var typeParametersExpression = string.Empty;
            if (typeParameters.Any())
            {
                typeParametersExpression = $"<{string.Join(",", typeParameters)}>";
            }

            var baseTypes = _typeDeclaration.BaseTypes
                .OfType<CodeTypeReference>()
                .Select(reference => _typescriptTypeMapper.GetTypeOutput(reference))
                .ToList();
            var baseTypesExpression = string.Empty;
            if (baseTypesExpression.Any())
            {
                baseTypesExpression = $" extends {string.Join(",", baseTypes)}";
            }

            return $"{accessModifier}{typeType} {name}{typeParametersExpression}{baseTypesExpression}{{{membersExpression}{Environment.NewLine}}}";

        }

        private string GetAccessModifier(MemberAttributes attributes)
        {
            return attributes == MemberAttributes.Public
                ? "export "
                : string.Empty;
        }

        private string GetTypeOfType(CodeTypeDeclaration typeDeclaration)
        {
            return typeDeclaration.IsEnum
                ? "enum"
                : typeDeclaration.IsInterface
                    ? "interface"
                    : "class";
        }
    }
}