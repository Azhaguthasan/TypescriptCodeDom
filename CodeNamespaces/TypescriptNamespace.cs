using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;
using TypescriptCodeDom.CodeStatements;
using TypescriptCodeDom.CodeTypeMembers;

namespace TypescriptCodeDom.CodeNamespaces
{
    class TypescriptNamespace : ITypescriptNamespace
    {
        private readonly IStatementFactory _statementFactory;
        private readonly IMemberFactory _memberFactory;
        

        public TypescriptNamespace(
            IStatementFactory statementFactory,
            IMemberFactory memberFactory)
        {
            _statementFactory = statementFactory;
            _memberFactory = memberFactory;
            
        }

        public string Expand(CodeNamespace codeNamespace, CodeGeneratorOptions options)
        {
            var name = codeNamespace.Name;
                       
            var comments = codeNamespace.Comments
                .OfType<CodeCommentStatement>()
                .Select(statement => _statementFactory.GetStatement(statement, options).Expand())
                .ToList();

            var commentsExpression = string.Empty;
            if (comments.Any())
            {
                commentsExpression = string.Join(Environment.NewLine, comments);
            }

            var importsExpression = codeNamespace.Imports
                .OfType<CodeNamespaceImport>()
                .Select(import => $"import {import.Namespace};")
                .ToList();

            var typesExpression = codeNamespace.Types
                .OfType<CodeTypeDeclaration>()
                .Select(declaration => $"{Environment.NewLine}{_memberFactory.GetMember(declaration, options).Expand()}")
                .ToList();

            return $"{importsExpression}{commentsExpression}{Environment.NewLine}module {name}{{{typesExpression}{Environment.NewLine}}}";

        }
    }
}
