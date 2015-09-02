using System.CodeDom;
using System.CodeDom.Compiler;
using TypescriptCodeDom.CodeExpressions;

namespace TypescriptCodeDom.CodeStatements
{
    class TypescriptAssignStatement : IStatement
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly CodeAssignStatement _codeAssignStatement;
        private readonly CodeGeneratorOptions _options;

        public TypescriptAssignStatement(
            IExpressionFactory expressionFactory,
            CodeAssignStatement codeAssignStatement,
            CodeGeneratorOptions options)
        {
            _expressionFactory = expressionFactory;
            _codeAssignStatement = codeAssignStatement;
            _options = options;
        }

        public string Expand()
        {
            var leftExpression = _expressionFactory.GetExpression(_codeAssignStatement.Left);
            var rightExpression = _expressionFactory.GetExpression(_codeAssignStatement.Right);

            return $"{leftExpression.Evaluate(_codeAssignStatement.Left, _options)} = ${rightExpression.Evaluate(_codeAssignStatement.Right, _options)};";
        }
    }
}